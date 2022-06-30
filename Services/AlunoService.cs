using padroes_projeto_api.Entities;
using padroes_projeto_api.Repositories;

namespace padroes_projeto_api.Services;

public class AlunoService
{
    private static AlunoService? _instance = null;

    private AlunoRepository alunoRepository;

    private AlunoService()
    {
        this.alunoRepository = AlunoRepository.GetInstance();
    }

    public static AlunoService GetInstance()
    {
        if (_instance == null)
        {
            _instance = new AlunoService();
        }

        return _instance;
    }

    public AlunoEntity? Insert(AlunoEntity alunoEntity)
    {
        if (this.alunoRepository.Select(alunoEntity.Matricula) != null)
        {
            return null;
        }

        this.alunoRepository.Insert(alunoEntity);

        return alunoEntity;
    }

    public AlunoEntity? Update(AlunoEntity alunoEntity)
    {
        if (this.alunoRepository.Select(alunoEntity.Matricula) != null)
        {
            this.alunoRepository.Update(alunoEntity);

            return alunoEntity;
        }

        return null;
    }

    public AlunoEntity? Delete(Int32 matricula)
    {
        AlunoEntity? alunoEntity = this.alunoRepository.Select(matricula);

        if (alunoEntity != null)
        {
            this.alunoRepository.Delete(matricula);

            return alunoEntity;
        }

        return null;
    }

    public AlunoEntity? Select(Int32 matricula)
    {
        return this.alunoRepository.Select(matricula);
    }

    public IEnumerable<AlunoEntity> GetAll()
    {
        return this.alunoRepository.GetAll();
    }
}