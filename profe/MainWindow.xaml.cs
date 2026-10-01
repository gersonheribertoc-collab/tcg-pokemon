using System;
using System.Collections.Generic;
using System.Windows;

namespace AlmacenPokemonWPF
{
    // 1. CLASE BASE (PADRE)
    public class ProductoBase
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public ProductoBase(int id, string nombre, decimal precio)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
        }

        // Método base de modificación de precio (evita valores negativos)
        public virtual void ActualizarPrecio(decimal nuevoPrecio)
        {
            Precio = Math.Max(0, nuevoPrecio);
        }
    }

    // 2. CLASE DERIVADA (HIJA) - HERENCIA
    public class ProductoPokemon : ProductoBase
    {
        public string Edicion { get; set; }

        public ProductoPokemon(int id, string nombre, decimal precio, string edicion)
            : base(id, nombre, precio) // Invoca al constructor de ProductoBase
        {
            Edicion = edicion;
        }

        // Método específico que utiliza la herencia al presionar los botones
        public void AplicarAjustePrecio(decimal monto)
        {
            ActualizarPrecio(Precio + monto); // Llama al método heredado de ProductoBase
        }
    }

    public partial class MainWindow : Window
    {
        private List<ProductoPokemon> almacen;

        public MainWindow()
        {
            InitializeComponent();

            // Instanciación de los 4 productos de TCG Pokémon
            almacen = new List<ProductoPokemon>
            {
                new ProductoPokemon(1, "Carta Charizard Holo 1st Ed.", 1500m, "Base Set"),
                new ProductoPokemon(2, "Elite Trainer Box Pikachu", 650m, "Scarlet & Violet"),
                new ProductoPokemon(3, "Booster Pack Mewtwo VMAX", 120m, "Crown Zenith"),
                new ProductoPokemon(4, "Lata Coleccionable Eevee", 380m, "Hidden Fates")
            };

            ActualizarInterfaz();
        }

        // Renderiza la información actualizada en las tarjetas WPF
        private void ActualizarInterfaz()
        {
            // Producto 1
            txtNombre1.Text = almacen[0].Nombre;
            txtEdicion1.Text = "Edición: " + almacen[0].Edicion;
            txtPrecio1.Text = "$" + almacen[0].Precio.ToString("F2");

            // Producto 2
            txtNombre2.Text = almacen[1].Nombre;
            txtEdicion2.Text = "Edición: " + almacen[1].Edicion;
            txtPrecio2.Text = "$" + almacen[1].Precio.ToString("F2");

            // Producto 3
            txtNombre3.Text = almacen[2].Nombre;
            txtEdicion3.Text = "Edición: " + almacen[2].Edicion;
            txtPrecio3.Text = "$" + almacen[2].Precio.ToString("F2");

            // Producto 4
            txtNombre4.Text = almacen[3].Nombre;
            txtEdicion4.Text = "Edición: " + almacen[3].Edicion;
            txtPrecio4.Text = "$" + almacen[3].Precio.ToString("F2");
        }

        // Manejadores de eventos para cada botón (ejecutan el método con herencia)
        private void BtnAumentar1_Click(object sender, RoutedEventArgs e) { almacen[0].AplicarAjustePrecio(50m); ActualizarInterfaz(); }
        private void BtnDisminuir1_Click(object sender, RoutedEventArgs e) { almacen[0].AplicarAjustePrecio(-20m); ActualizarInterfaz(); }

        private void BtnAumentar2_Click(object sender, RoutedEventArgs e) { almacen[1].AplicarAjustePrecio(50m); ActualizarInterfaz(); }
        private void BtnDisminuir2_Click(object sender, RoutedEventArgs e) { almacen[1].AplicarAjustePrecio(-20m); ActualizarInterfaz(); }

        private void BtnAumentar3_Click(object sender, RoutedEventArgs e) { almacen[2].AplicarAjustePrecio(50m); ActualizarInterfaz(); }
        private void BtnDisminuir3_Click(object sender, RoutedEventArgs e) { almacen[2].AplicarAjustePrecio(-20m); ActualizarInterfaz(); }

        private void BtnAumentar4_Click(object sender, RoutedEventArgs e) { almacen[3].AplicarAjustePrecio(50m); ActualizarInterfaz(); }
        private void BtnDisminuir4_Click(object sender, RoutedEventArgs e) { almacen[3].AplicarAjustePrecio(-20m); ActualizarInterfaz(); }
    }
}