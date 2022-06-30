using Microsoft.AspNetCore.Mvc;
using padroes_projeto_api.Entities;
using padroes_projeto_api.Views;
using padroes_projeto_api.Services;

namespace padroes_projeto_api.Controllers;

[ApiController]
[Route("alunos")]
public class AlunoController : ControllerBase
{
    [HttpPost]
    public IActionResult Insert(AlunoEntity alunoEntity)
    {
        AlunoEntity? result = AlunoService.GetInstance().Insert(alunoEntity);

        if (result != null)
        {
            return Ok(result);
        }

        return StatusCode(500, "Aluno já cadastrado");
    }

    [HttpPut("{matricula}")]
    public IActionResult Update([FromRoute] Int32 matricula, AlunoEditView alunoEditView)
    {
        AlunoEntity? result = AlunoService.GetInstance().Update(new AlunoEntity
        {
            Matricula = matricula,
            Nome = alunoEditView.Nome
        });

        if (result != null)
        {
            return Ok(result);
        }

        return StatusCode(404, "Aluno não encontrado");
    }

    [HttpDelete("{matricula}")]
    public IActionResult Delete([FromRoute] Int32 matricula)
    {
        AlunoEntity? result = AlunoService.GetInstance().Delete(matricula);

        if (result != null)
        {
            return Ok(result);
        }

        return StatusCode(404, "Aluno não encontrado");
    }

    [HttpGet]
    public IEnumerable<AlunoEntity> GetAll()
    {
        return AlunoService.GetInstance().GetAll();
    }

    [HttpGet("{matricula}")]
    public IActionResult GetByMatricula([FromRoute] Int32 matricula)
    {
        AlunoEntity? result = AlunoService.GetInstance().Select(matricula);

        if (result != null)
        {
            return Ok(result);
        }

        return StatusCode(404, "Aluno não encontrado");
    }
}
