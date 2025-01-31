using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeNotas.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeNotas.Controllers
{
    public class NotaAlunoController : Controller
  
    {
        // Banco de dados 
        private readonly AppDbContext _context;

        public NotaAlunoController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Consulta as notas no banco
            var notasAlunos = await _context.NotasAlunos.ToListAsync();
            return View(notasAlunos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NotaAluno notaAluno)
        {
            if (ModelState.IsValid)
            {
                //Salva uma nova nota do aluno 
                _context.NotasAlunos.Add(notaAluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notaAluno);
        }

        public async Task<IActionResult> CalcularMedias()

        {

            var notasAlunos = await _context.NotasAlunos.ToListAsync();

            if (!notasAlunos.Any())

            {

                TempData["Mensagem"] = "Nenhum aluno cadastrado.";

                return RedirectToAction(nameof(Index));

            }

           

            double mediaTurma = notasAlunos.Average(n => n.CalcularMedia());

            

            TempData["MediaTurma"] = mediaTurma.ToString("F2"); 

            return RedirectToAction(nameof(Index));

        }


    }
}
