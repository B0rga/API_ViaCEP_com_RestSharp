using RestSharp;

public class Endereco{

    public void InvocarGet(){ // método que irá solicar o cep e fazer o request do conteúdo
        string cep = string.Empty;
        Console.Write("Insira o cep desejado: ");
        cep = Console.ReadLine();

        var client = new RestClient ($"https://viacep.com.br/ws/{cep}/json/"); // criando instância que irá receber os valores da api através do cep desejado
        RestRequest request = new RestRequest("", Method.Get); // criando request e especificando que é do tipo GET
        var response = client.Execute(request); // esta variável serve para receber o status da operação; é a RESPOSTA que será recebida ao final do request

        if(response.StatusCode == System.Net.HttpStatusCode.OK){ // se a resposta (response) foi de sucesso, o conteúdo será recebido
            Console.WriteLine(response.Content); // response.Content = Conteúdo recebido
        }
        else{ // caso a resposta não for de sucesso, um erro será notificado
            Console.WriteLine(response.ErrorMessage);
        }
        Console.ReadKey(); // o programa somente será finalizado após qualquer tecla ser pressionada
    }

    public void InvocarPost(){ // este método trabalhará diretamente com o gerador de API "Mokcy", para retornar uma resposta personalizada
        // o processo de request é quase o mesmo que o anterior
        
        var client = new RestClient ($"https://run.mocky.io/v3/cb809715-f2f8-47b7-8efc-838d6e63341c"); // aqui a instânica irá receber a API que criamos através do Mocky.io:
        RestRequest request = new RestRequest("", Method.Post); // criando request e especificando que é do tipo POST
        request.AddJsonBody(new{ Id = 5 });
        var response = client.Execute(request);

        if(response.StatusCode == System.Net.HttpStatusCode.OK){
            Console.WriteLine(response.Content); // se a resposta for um sucesso, é para retornar "Sucesso":"true"
        }
        else{
            Console.WriteLine(response.ErrorMessage);
        }
        Console.ReadKey();    
    }
}

class Program{
    static void Main(){
        Console.Clear();
        Endereco endereco1 = new Endereco();
        endereco1.InvocarGet();
        endereco1.InvocarPost();
    }
}