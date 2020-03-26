using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskList.Api.Data;
using TaskList.Domain.Models;

namespace TaskList.Api.Controllers
{
    [ApiController]
    [Route("v1/tasks")]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        [Route("get-tasks")]
        public async System.Threading.Tasks.Task<ActionResult<List<Task>>> GetTasks([FromServices] DataContext context)
        {
            var tasks = await context.Tasks.ToListAsync();

            return tasks;
        }

        [HttpGet]
        [Route("get-task")]
        public async System.Threading.Tasks.Task<ActionResult<Task>> GetTask([FromServices] DataContext context, int id)
        {
            var task = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            return task;
        }

        [HttpGet]
        [Route("delete-task")]
        public async System.Threading.Tasks.Task<ActionResult<Task>> DeleteTask(
            [FromServices] DataContext context,
             int id)
        {
            if (ModelState.IsValid)
            {
                var task = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

                context.Tasks.Remove(task);

                await context.SaveChangesAsync();

                return task;
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("update-task")]
        public async System.Threading.Tasks.Task<ActionResult<Task>> UpdateTask(
            [FromServices] DataContext context,
            [FromBody] Task task)
        {
            if (ModelState.IsValid)
            {
                task.EditDate = DateTime.Now;

                if (task.Status == TaskStatus.Concluded)
                {
                    task.ConcludedDate = DateTime.Now;
                }

                context.Tasks.Update(task);

                await context.SaveChangesAsync();

                return task;
            }

            return BadRequest(ModelState);
        }


        [HttpPost]
        [Route("add-task")]
        public async System.Threading.Tasks.Task<ActionResult<Task>> AddTask(
            [FromServices] DataContext context,
            [FromBody] Task task)
        {
            if (ModelState.IsValid)
            {
                task.CreationDate = DateTime.Now;

                context.Tasks.Add(task);
                await context.SaveChangesAsync();

                return task;
            }

            return BadRequest(ModelState);
        }
    }
}