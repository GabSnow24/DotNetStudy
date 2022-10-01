namespace estudo_c_.Services.Interfaces;
public interface IGenericService<T> where T : class {
    
    IEnumerable<T> GetAll();
    T Remove (int id);
}