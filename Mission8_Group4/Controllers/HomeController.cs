using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission8_Group4.Models;
using Task = Mission8_Group4.Models.Task;
//Imports
namespace Mission8_Group4.Controllers;

public class HomeController : Controller
{
    private readonly Mission8Group4 _context;

    public HomeController(Mission8Group4 context)
    {
        _context = context;
    } //context initializer 

    public IActionResult Index() //Index route
    {
        return View();
    }

    public IActionResult Add() // GET ADD
    {
        ViewBag.Categories = new SelectList(_context.Categories.ToList(), "id", "name");
        return View();
    }

    [HttpPost]
    public IActionResult Add(Task task) //POST ADD
    {
        if (ModelState.IsValid)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return RedirectToAction("Quadrants");
        }
        ViewBag.Categories = new SelectList(_context.Categories.ToList(), "id", "name");
        return View(task);
    }

    public IActionResult Edit(int id) // GET edit view
    {
        var task = _context.Tasks.FirstOrDefault(t => t.id == id);
        if (task == null)
        {
            return NotFound();
        }

        ViewBag.Categories = new SelectList(_context.Categories.ToList(), "id", "name");
        return View(task);
    }

    [HttpPost]
    public IActionResult Edit(Task task) //POST 
    {
        if (ModelState.IsValid)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
            return RedirectToAction("Quadrants");
        }
        ViewBag.Categories = new SelectList(_context.Categories.ToList(), "id", "name");
        return View(task);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var task = _context.Tasks.FirstOrDefault(t => t.id == id);
        if (task != null)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        return RedirectToAction("Quadrants");
    }

    [HttpPost]
    public IActionResult MarkCompleted(int id)
    {
        var task = _context.Tasks.FirstOrDefault(t => t.id == id);
        if (task == null)
        {
            return NotFound();
        }

        task.completed = true; 
        _context.Tasks.Update(task);
        _context.SaveChanges();
        return RedirectToAction("Quadrants");
    }


    public IActionResult Quadrants()
    {
        var tasks = _context.Tasks.Where(t => t.completed == false).ToList();
        return View(tasks);
    }
}
