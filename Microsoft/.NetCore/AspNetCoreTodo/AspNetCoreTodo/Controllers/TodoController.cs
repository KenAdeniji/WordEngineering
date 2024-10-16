using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using AspNetCoreTodo.Services;

namespace AspNetCoreTodo.Controllers
{
	public class TodoController : Controller
	{
		private readonly ITodoItemService _todoItemService;
		public TodoController(ITodoItemService todoItemService)
		{
			_todoItemService = todoItemService;
		}
		public async Task<IActionResult> Index()
		{
			var items = await _todoItemService.GetIncompleteItemsAsync();
			// Put items into a model
			// Pass the view to a model and render
		}		
	}	
}