
namespace ProyectoFinal_ProgramacionParalela.Models;

/// <summary>
/// Representa un producto en el inventario.
/// </summary>
public class Producto
{
    /// <summary>
    /// El identificador único del producto.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// El nombre del producto. Se inicializa como "not null!" para satisfacer al compilador.
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// La categoría a la que pertenece el producto.
    /// </summary>
    public string Categoria { get; set; } = null!;

    /// <summary>
    /// El precio del producto. Se usa 'decimal' para mayor precisión en cálculos monetarios.
    /// </summary>
    public decimal Precio { get; set; }

    /// <summary>
    /// La marca del producto.
    /// </summary>
    public string Marca { get; set; } = null!;
}
