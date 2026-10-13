namespace MauiAppCombustivel
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                string marca = txt_marca.Text?.Trim() ?? "";
                string modelo = txt_modelo.Text?.Trim() ?? "";

                if(marca == "" || modelo == "")
                {
                    await DisplayAlertAsync("Erro", "Por favor, preencha todos os campos.", "OK");
                    return;
                }

                if (!double.TryParse(
                        txt_etanol.Text?.Replace(",", "."),
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out double etanol) ||
                    !double.TryParse(
                        txt_gasolina.Text?.Replace(",", "."),
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out double gasolina) ||
                    etanol <= 0 || gasolina <= 0)
                {
                    await DisplayAlertAsync("Atenção", "Informe preços válidos e maiores que zero.", "OK");

                    return;
                }

                string msg = "";
                if (etanol <= (gasolina * 0.7))
                {
                    msg = $"O etanol é mais vantajoso para seu {marca} {modelo}.";
                } else
                {
                    msg = $"A gasolina é mais vantajosa para seu {marca} {modelo}.";
                }

                await DisplayAlertAsync("Calculado", msg, "OK");

            } catch(Exception ex)
            {
                await DisplayAlertAsync("Ops", ex.Message, "Fechar");
            }
        }
    }
}
