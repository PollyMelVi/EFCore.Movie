using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MoviesApp.Filters;
using MoviesApp.Services;
using MoviesApp.Services.Dto;
using MoviesApp.ViewModels;

namespace MoviesApp.Controllers;

public class ActorsController : Controller
{
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IActorService _service;


        public ActorsController (ILogger<HomeController> logger, IMapper mapper, IActorService service)
        {
            _logger = logger;
            _mapper = mapper;
            _service = service;
        }

        // GET: Actors
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var actor = _mapper.Map<IEnumerable<ActorDto>, IEnumerable<ActorViewModel>>(_service.GetAllActors());
            return View(actor);
        }

        // GET: Actors/Details/5
        [HttpGet]
        [Authorize]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
        
            var viewModel = _mapper.Map<ActorViewModel>(_service.GetActor((int) id));
            
            if (viewModel == null)
            {
                return NotFound();
            }
        
            return View(viewModel);
        }
        
        // GET: Actors/Create
        [HttpGet]
        [Authorize(Roles = "Admin")] 
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")] 
        [ValidateAntiForgeryToken]
        [CheckingTheAgeOfActor]
        public IActionResult Create([Bind("Name, LastName, BirthDate")] InputActorViewModel inputModel)
        {
            if (ModelState.IsValid)
            {
                _service.AddActor(_mapper.Map<ActorDto>(inputModel));
                return RedirectToAction(nameof(Index));
            }
            return View(inputModel);
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")] 
        // GET: Actors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editModel = _mapper.Map<EditActorViewModel>(_service.GetActor((int) id));
            
            if (editModel == null)
            {
                return NotFound();
            }
            
            return View(editModel);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")] 
        [ValidateAntiForgeryToken]
        [CheckingTheAgeOfActor]
        public IActionResult Edit(int id, [Bind("Name, LastName, BirthDate")] EditActorViewModel editModel)
        {
            if (ModelState.IsValid)
            {
                var actor = _mapper.Map<ActorDto>(editModel);
                actor.Id = id;
                 
                var result = _service.UpdateActor(actor);

                if (result == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(editModel);
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")] 
        // GET: Actors/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deleteModel = _mapper.Map<DeleteActorViewModel>(_service.GetActor((int) id));
            
            if (deleteModel == null)
            {
                return NotFound();
            }

            return View(deleteModel);
        }
        
        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")] 
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var actor = _service.DeleteActor(id);
            if (actor==null)
            {
                return NotFound();
            }
            _logger.LogError($"Actor with id {actor.Id} has been deleted!");
            return RedirectToAction(nameof(Index));
        }
        
    }