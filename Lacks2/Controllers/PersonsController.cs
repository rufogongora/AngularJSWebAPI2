using AutoMapper;
using Lacks2.Models;
using Lacks2.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using RefactorThis.GraphDiff;

namespace Lacks2.Controllers
{
    [RoutePrefix("api/persons")]
    public class PersonsController : ApiController
    {

        private AppContext db = new AppContext();

        //Get the general list of users (on bigger apps should use pagination)
        [HttpGet]
        public async Task<IHttpActionResult> Get() {
            List<Person> Persons = await db.Persons.ToListAsync();
            return Ok(Mapper.Map<List<PersonViewModel>>(Persons));
            
        }

        //add a new person
        [HttpPost]
        public async Task<IHttpActionResult> Post(PersonViewModel newPerson) {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Model");
            Person newPersonModel = Mapper.Map<Person>(newPerson);
            db.Persons.Add(newPersonModel);
            await db.SaveChangesAsync();

            return Ok(Mapper.Map<PersonViewModel>(newPersonModel));
        }


        //delete something, typically you would use the [Authorize] attribute on a delete operation
        [HttpDelete, Route("{id:int}")]
        public async Task<IHttpActionResult> Delete(int id) {
            Person person = await db.Persons.Where(p => p.Id == id).FirstOrDefaultAsync();

            if (person == null)
                return BadRequest("Invalid Person");

            db.Persons.Remove(person);
            await db.SaveChangesAsync();
            return Ok();
        }


        //Update the requested model
        [HttpPut, Route("{id:int}")]
        public async Task<IHttpActionResult> Put(PersonViewModel person, int id) {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Model");

            Person personFromDb = await db.Persons.Where(p => p.Id == id).AsNoTracking().FirstOrDefaultAsync();

            if (personFromDb == null)
                return BadRequest("Invalid person id");

            Mapper.Map(person, personFromDb);

            Mapper.Map(person.Foods, personFromDb.Foods);
            //order food
            int i = 0;
            foreach(var f in personFromDb.Foods) {
                f.Order = i;
                i++;
            }
            //for some reason this method is not updating the properties on the children objects
            db.UpdateGraph(personFromDb,
                map =>
                map.OwnedCollection(p => p.Foods));
            await db.SaveChangesAsync();
            
            //therefore we have to get the same object from the db again... must check afterwards
            Person response = await db.Persons.Where(p => p.Id == id).AsNoTracking().FirstOrDefaultAsync();

            return Ok(Mapper.Map<PersonViewModel>(response));
        }
    }
}
