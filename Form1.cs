namespace Pokedex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string buscar = textBuscar.Text;
            Leer(buscar);
        }

        private async Task Leer(string _buscar)
        {
            using var cliente = new HttpClient();
            var resultado = await cliente.GetStringAsync(" https://pokeapi.co/api/v2/pokemon/" + _buscar);
            var pokemon = Pokemon.FromJson(resultado);
            pictureBox1.Load(pokemon.Sprites.Front_default.ToString());
            labelNombre.Text = pokemon.Name;
            labelId.Text = pokemon.Id;

        

            labelMovimiento1.Text = pokemon.Moves[0].Move.Name;
            labelMovimiento2.Text = pokemon.Moves[1].Move.Name;
            labelMovimiento3.Text = pokemon.Moves[2].Move.Name;
            labelMovimiento4.Text = pokemon.Moves[3].Move.Name;

            labelVida.Text = pokemon.Stats[0].Base_stat;
            labelAtaque.Text = pokemon.Stats[1].Base_stat;
            labelDefensa.Text = pokemon.Stats[2].Base_stat;
            labelVelocidad.Text = pokemon.Stats[5].Base_stat;

            try 
            {
                labelTipo.Text =pokemon.Types[1].Type.Name;
            } 
            catch (Exception) 
            {
                labelTipo.Text = pokemon.Types[0].Type.Name;
            }
            

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}