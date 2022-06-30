using padroes_projeto_api.Entities;

namespace padroes_projeto_api.Repositories;

public class AlunoRepository
{
    private static AlunoRepository? _instance = null;

    private Dictionary<Int32, AlunoEntity> alunos { set; get; }

    private AlunoRepository()
    {
        this.alunos = new Dictionary<Int32, AlunoEntity>();
    }

    public static AlunoRepository GetInstance()
    {
        if (_instance == null)
        {
            _instance = new AlunoRepository();
        }

        return _instance;
    }

    public void Insert(AlunoEntity alunoEntity)
    {
        this.alunos.Add(alunoEntity.Matricula, alunoEntity);
    }

    public void Update(AlunoEntity alunoEntity)
    {
        this.alunos.Remove(alunoEntity.Matricula);
        this.alunos.Add(alunoEntity.Matricula, alunoEntity);
    }

    public void Delete(Int32 matricula)
    {
        this.alunos.Remove(matricula);
    }

    public AlunoEntity? Select(Int32 matricula)
    {
        if (this.alunos.ContainsKey(matricula))
        {
            return this.alunos[matricula];
        }

        return null;
    }

    public IEnumerable<AlunoEntity> GetAll()
    {
        return this.alunos.Values;
    }
}