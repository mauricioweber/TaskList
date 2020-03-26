using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskList.Data;
using TaskList.Models;
using Task = TaskList.Domain.Models.Task;

namespace TaskList.Controllers
{
    public class TasksController : Controller
    {
        private readonly IMapper _mapper;

        public TasksController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var list = _mapper.Map<List<TaskViewModel>>(await TasksContext.GetTasks());

            return View(list);
        }


        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var tasks = await TasksContext.GetTasks();

            var task = tasks.FirstOrDefault(m => m.Id == id);

            if (task == null) return NotFound();


            return View(_mapper.Map<TaskViewModel>(task));
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Title,Description,Status,CreationDate,EditDate,RemovedDate,ConcludedDate")]
            TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                await TasksContext.AddTask(_mapper.Map<Task>(task));

                return RedirectToAction(nameof(Index));
            }

            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var task = await TasksContext.GetTask(id.Value);

            if (task == null) return NotFound();

            return View(_mapper.Map<TaskViewModel>(task));
        }


        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Title,Description,Status,CreationDate,EditDate,ConcludedDate")]
            TaskViewModel taskViewModel)
        {
            if (id != taskViewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    TasksContext.UpdateTask(_mapper.Map<Task>(taskViewModel));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await TaskExists(taskViewModel.Id))
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(taskViewModel);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();


            var task = await TasksContext.GetTask(id.Value);

            if (task == null) return NotFound();

            return View(_mapper.Map<TaskViewModel>(task));
        }

        // POST: Tasks/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await TasksContext.DeleteTask(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TaskExists(int id)
        {
            return await TasksContext.GetTask(id) != null;
        }
    }
}