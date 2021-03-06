﻿using ExpensesAPI.Data;
using ExpensesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ExpensesAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers:"*", methods:"*")]
    public class EntriesController : ApiController
    {
        public IHttpActionResult Getentries()
        {
            try
            {

            using(var context = new AppDbContext())
            {
                var entries = context.Entries.ToList();
                return Ok(entries);
            }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult PostEntry([FromBody] Entry entry)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                using (var context = new AppDbContext())
                {
                    context.Entries.Add(entry);
                    context.SaveChanges();

                    return Ok("Entry was created.");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
