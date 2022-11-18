namespace StudentService.Service
{
    public interface IStudentRepository
    {
        List<Model.Student> GetAll();
        Model.Student Get(int id);
        Task Create(Model.Student student);
        Task Update(int id, Model.Student student);
        Task Delete(int id);
    }
}
