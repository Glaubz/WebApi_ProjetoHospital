using System.Threading.Tasks;
using ProjetoUnip.Domain.Person;
using ProjetoUnip.Domain.User;
using ProjetoUnip.Domain.Util;

namespace ProjetoUnip.Repository
{
    public interface IProjetoUnipRepository
    {
         //GERAL
         void add<T>(T entity) where T : class;
         void update<T>(T entity) where T : class;
         void delete<T>(T entity) where T : class;
         Task<bool> SaveChangesAsync();

         //USUARIOS
         Task<Usuario[]> GetAllUsuariosAsync();
         Task<Usuario> GetUsuarioAsyncById(int usuarioId);
         Task<Usuario> GetUsuarioAsyncById(string Nome, string senha);

        //MEDICOS
        Task<Medico[]> GetAllMedicosAsync();
        Task<Medico> GetMedicoAsyncById(int medicoId);
        Task<Medico[]> GetAllMedicosAsyncByName(string nomeMedico);

        //PACIENTES
        Task<Paciente[]> GetAllPacientesAsync();
        Task<Paciente> GetPacienteAsyncById(int pacienteId);
        Task<Paciente[]> GetAllPacientesAsyncByName(string nomePaciente);
        
        //FUNCIONARIOS
        Task<Funcionario[]> GetAllFuncionariosAsync();
        Task<Funcionario> GetFuncionarioAsyncById(int funcionarioId);
        Task<Funcionario> GetFuncionarioAsyncByUsuarioId(int usuarioId);
        Task<Funcionario[]> GetAllFuncionariosAsyncByName(string nomeFuncionario);
        Task<Funcionario[]> GetAllFuncionariosAsyncByCpf(string cpf);
        
        //CONSULTAS
        Task<Consulta[]> GetAllConsultasAsync();
        Task<Consulta> GetConsultaAsyncById(int consultaId);
        //Task<Consulta[]> GetAllConsultasAsyncByName(string nomeConsulta);

        //MEDICO-CONSULTA
        Task<MedicoConsulta[]> GetAllMedicosConsultasAsync();
        Task<MedicoConsulta> GetMedicoConsultaAsyncById(int medicoConsultaId);
    }
}