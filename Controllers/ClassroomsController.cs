﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Laboratorio3.Models;

namespace Laboratorio3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        private readonly Laboratorio3ApiContext _context;

        public ClassroomsController(Laboratorio3ApiContext context)
        {
            _context = context;
        }

        // GET: api/Classrooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classroom>>> GetClassroom()
        {
            return await _context.Classroom.ToListAsync();
        }

        // GET: api/Classrooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Classroom>> GetClassroom(int id)
        {
            var classroom = await _context.Classroom.FindAsync(id);

            if (classroom == null)
            {
                return NotFound();
            }

            return classroom;
        }

        // PUT: api/Classrooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassroom(int id, Classroom classroom)
        {
            if (id != classroom.Id)
            {
                return BadRequest();
            }

            _context.Entry(classroom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassroomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Classrooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Classroom>> PostClassroom(Classroom classroom)
        {
            _context.Classroom.Add(classroom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassroom", new { id = classroom.Id }, classroom);
        }

        // DELETE: api/Classrooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassroom(int id)
        {
            var classroom = await _context.Classroom.FindAsync(id);
            if (classroom == null)
            {
                return NotFound();
            }

            _context.Classroom.Remove(classroom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("getByHasAireAcondicionado")]
        public async Task<IActionResult> GetClassroomsByHasAire()
        {
            var classroomsWithAire = await _context.Classroom
                .Where(a => a.TieneAireAcondicionado == true)
                .ToListAsync();

            return Ok(classroomsWithAire);
        }


        private bool ClassroomExists(int id)
        {
            return _context.Classroom.Any(e => e.Id == id);
        }
    }
}
