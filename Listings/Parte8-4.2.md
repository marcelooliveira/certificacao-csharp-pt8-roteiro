### Habilidade 4.2: Consumir dados

Na seção anterior, vimos como criar arquivos e armazenar dados
neles. Nesta seção, você verá o armazenamento de dados
técnicas que constroem em um armazenamento de arquivos para sustentar o trabalho
aplicações. Inicialmente, você verá como um mecanismo de banco de dados pode
expor informações aos aplicativos. Então você vai dar uma
veja como usar XML e J SON para impor estrutura em um arquivo
de dados armazenados. Finalmente, você vai investigar serviços da web,
Que permitem que um programa exponha dados a outros programas em um
rede de forma portátil.

Esta seção aborda como:

* Recuperar dados de um banco de dados
* Atualizar dados em um banco de dados

Eu Consumo J SON e dados XML I
Recuperar dados usando serviços da web
Recuperar dados de um banco de dados
Na Habilidade 3.2, no “Use o Entity Framework para projetar seu
armazenamento de dados ”você viu como usar um projeto baseado em classe para
expressar as necessidades de armazenamento de dados de um aplicativo para armazenar
informações sobre faixas de música. Nós projetamos uma classe chamada
Musi cTraCk e, em seguida, usou o conjunto de ferramentas do Entity Framework
Visual Studio para criar automaticamente o banco de dados subjacente.
Antes de ler mais você gostaria de revisitar
seção para se lembrar do que estávamos tentando fazer, e como
nós fizemos isso. Se você quiser usar as amostras de banco de dados nesta seção
você pode executar as etapas na Habilidade 3.2 para criar seu próprio local
arquivo de banco de dados.

Um único servidor de banco de dados SQL pode fornecer armazenamento de dados para ser
compartilhado entre um grande número de clientes. O servidor pode ser executado
a mesma máquina que o programa que está usando o banco de dados ou
o servidor pode ser acessado através de uma conexão de rede. Desenvolvedores
pode trabalhar com a versão de desenvolvimento do servidor de banco de dados
executando em sua máquina, antes de criar um servidor dedicado para
o pedido publicado. O aplicativo MusicTracks que nós
trabalhou Com na Skill 3.2 usou um banco de dados local em execução em um
máquina em modo de desenvolvimento. Mais tarde nesta seção, vamos
Considere como gerenciar o ambiente de um aplicativo ASP
para permitir que ele use um servidor de banco de dados remoto quando ele é executado em um
servidor de produção.

### Dados em um banco de dados

O código a seguir mostra a classe MusicTrack que é usada no
Aplicação MusicTracks. A classe contém membros de dados que
armazene o Artista, Título e Comprimento de uma faixa de música. o
classe também contém um valor de ID inteiro, que será usado pelo
banco de dados para permitir a identificação exclusiva de cada faixa de música
armazenado.

public class Musici’rack
{
public int ID { get; set; }
public string Artist { get; set; }
public string Title { get; set; }
public int Length { get; set; }

O conjunto de ferramentas do Entity Framework usa a definição de classe para
produzir uma tabela em um banco de dados que tenha o armazenamento de dados necessário.
A Tabela 4.1 mostra a tabela do banco de dados criada para o
Classe MusicTrack. Cada linha na tabela equivale a uma instância
da classe MusicTrack. A tabela contém três músicas. Cada
música tem um valor de ID diferente. O banco de dados foi configurado
para criar automaticamente valores de ID Quando uma nova entrada do MusicTrack
é criado.

### TABELA 4-1 Tabela MusicTrack


De um ponto de design de dados de Exibir uma tabela em um banco de dados pode ser
considerado como uma coleção de objetos. Em outras palavras, a tabela em
A Tabela 4–1 pode ser vista como uma lista de referências a
MusicTrack objetos em um programa C #. Criando um programa para
ler os dados em uma tabela de banco de dados, no entanto, é o mesmo que
acessando um elemento em uma lista c #. Um programa tem que fazer
conexão com o banco de dados e, em seguida, enviar o banco de dados
comando para solicitar as informações MusicTrack.

### Leia com SQL

O banco de dados no aplicativo MusicTracks é gerenciado por um
processo do servidor que aceita comandos e age sobre eles. o
os comandos são dados em um formato chamado Consulta Estruturada

Linguagem (SQL). O SQL remonta aos anos 70. É chamado de
linguagem específica do domínio, porque é usada apenas para expressar
comandos para informar um banco de dados O que fazer.
SQL é muito útil. Por exemplo, um dia o usuário do seu
programa de faixa de música pode pedir-lhe para fazer o programa
produzir uma lista de todas as faixas de um determinado artista. Isso seria
ser fácil de fazer se todas as faixas musicais estiverem em uma lista. Você pode
escrever um loop for que funcione na lista procurando por faixas
com um nome particular. Então, no dia seguinte, o usuário pode pedir
uma lista de faixas ordenadas por faixa, e no dia seguinte você
pode ser perguntado por todos os artistas que gravaram uma faixa
chamado "My Way", que tem mais de 120 segundos. Cada vez que você
são convidados para uma nova visão dos dados que você tem que escrever um pouco mais
C# para pesquisar a lista de faixas e produzir o resultado.
No entanto, se as informações da faixa musical forem mantidas em um banco de dados,
cada uma dessas solicitações pode ser satisfeita criando uma consulta SQL
para obter os dados.

A primeira consulta SQL que vamos realizar no
O banco de dados MusicTracks tem o formulário mostrado a seguir. O personagem
é um "caractere curinga" que corresponde a todas as entradas na tabela. este
comando informa ao servidor de banco de dados que nosso programa quer
leia todos os elementos da tabela MusicTrack.

SELECT * FROM MusicTrack

Agora que temos nosso comando SQL, vamos descobrir como
apresentar o comando ao banco de dados. Um programa usa um SQL
banco de dados de maneira semelhante a um fluxo. O programa cria um
objeto que representa uma conexão com o banco de dados e, em seguida,
envia comandos SQL para este objeto. A conexão do banco de dados
mecanismo também é organizado da mesma forma que o
classes de fluxo de entrada / saída. A classe DbConnection que
representa uma conexão com um banco de dados é uma classe abstrata que
descreve os comportamentos da conexão da mesma forma que
a classe Stream também é abstrata e descreve os comportamentos de
fluxos. O SqlConne cti na classe é um filho do
Classe DbConnection e representa a implementação de um
conexão com um banco de dados SQL.

Para fazer uma conexão com um banco de dados, um programa deve criar um
Objeto SqlConnection. O construtor para o
A classe SqlConnection recebe uma string de conexão que
identifica o banco de dados a ser aberto. Antes de podermos começar
para ler a partir do banco de dados, precisamos considerar como o
A string de conexão é usada para gerenciar a conexão.
A cadeia de conexão contém vários itens expressos
como pares nome-valor. Para um servidor em uma máquina remota, o
seqüência de conexão conterá o endereço do servidor, a porta
em que o servidor está escutando e um par nome de usuário / senha
que pode autenticar a conexão.

No caso do aplicativo MusicTracks que criamos
anteriormente, essa string de conexão era criada automaticamente e
descreve uma conexão com um arquivo de banco de dados local mantido no
computador na pasta para o usuário. Se você seguiu as etapas
Capítulo 3 para construir seu próprio aplicativo, o arquivo de banco de dados será
criado na sua máquina.

O programa na Listagem 4-19 mostra como um programa C # pode
fazer uma conexão com um banco de dados, criar uma consulta SQL e, em seguida,
executar esta consulta no banco de dados para ler e imprimir
informações da tabela Mus icTrack. O programa imprime
o Artista e Título de cada faixa de música no banco de dados.

### LISTA 4-19 Ler com o SQL

```csharp
private const string DatabaseServer = "(LocalDB)\\MSSQLLocalDB";
private const string DatabaseName = "Cinema";
static void Main(string[] args)
{
	string connectionString = $"Server={DatabaseServer};Integrated security=SSPI;database={DatabaseName}";

	using (SqlConnection connection = new SqlConnection(connectionString))
	{
		connection.Open();
		SqlCommand command = new SqlCommand(
			" SELECT d.Nome AS Diretor, f.Titulo AS Titulo" +
			" FROM Filmes AS f" +
			" INNER JOIN Diretores AS d" +
			"   ON d.Id = f.DiretorId"
			, connection);
		SqlDataReader reader = command.ExecuteReader();

		while (reader.Read())
		{
			string diretor = reader["Diretor"].ToString();
			string titulo = reader["Titulo"].ToString();
			Console.WriteLine("Diretor: {0} Titulo: {1}", diretor, titulo);
		}
	}

	Console.ReadKey();
}
```		

A string de conexão no programa faz uma comi-
o banco de dados MusicTracks. Note que é importante que o
A string de conexão não é “hard mired” no código-fonte do programa.
O programa na Listagem 4-19 é apenas um exemplo, não como você
deve criar código de produção. Qualquer um que obtenha a fonte
código deste programa pode visualizar a string de conexão e obter
acesso ao banco de dados e qualquer pessoa que obtiver o compilado
A versão do programa pode usar uma ferramenta como ilda sm para
Código MSIL e extrair a conexão. Você também teria que
mudar o código do programa cada vez que você quiser usar um
banco de dados diferente.

### Gerenciamento de Cadeia de Conexão no ASP.NET

A cadeia de conexão do banco de dados a ser usada por um ASP.NET
aplicação é mantida na informação de configuração para o
solução. Isso é armazenado no arquivo appsettings. j filho no
solução. A localização desse arquivo é mostrada na Figura 4—7, que
mostra os arquivos de solução para o aplicativo MusicTracks.

### FIGURA 4-7 O arquivo appsettings.json

A solução na Figura 4-7 tem um arquivo de configuração
configurações do aplicativo . Desenvolvimento. j filho que contém personalizado
configurações para uso durante o desenvolvimento. Se você adicionar um
configurações do aplicativo . Produção . j filho para a solução, você pode
criar informações de configurações que serão usadas quando o programa for
executando em um servidor de produção. Os appsettings. arquivo j filho
para a aplicação MusicTracks na minha máquina contém o
seguinte:

```
{
  "Logging": {
    "IncludeScopes": false,
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "ConnectionStrings": {
    "MusicTrackDBContext": "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\marce\\Documents\\GitHub\\certificacao-csharp-pt8-roteiro\\Listings\\Cinema.mdf;Integrated Security=True"
  }
}
```

O elemento ConnectionStrings no arquivo de configurações
contém a string de conexão para o banco de dados do MusicTracks
contexto. O nome do banco de dados que é criado quando a solução é
criado tem um identificador globalmente exclusivo (GUID) acrescentado,
nome do banco de dados em sua máquina será diferente de
meu. Se você deseja executar as amostras de banco de dados que seguem
texto você terá que copiar sua seqüência de conexão para o
programas de exemplo.

As informações de configuração em uma solução podem conter
descrições de ambientes que devem ser usados para
implementações de desenvolvimento e produção de um aplicativo. o
ambientes utilizados para a implantação de aplicativos
seqüência de conexão de banco de dados e quaisquer outras opções que você faria
gostaria de personalizar. Por exemplo, o ambiente de desenvolvimento
pode usar um servidor de banco de dados local e o ambiente de produção
pode usar um servidor distante.

A informação de configuração a ser usada é Quando um servidor é iniciado
e determinado por uma variável de ambiente no computador
que é testado Quando o programa começa a ser executado. A palavra
ambiente está sendo usado em dois contextos diferentes neste
situação, que pode ser confuso.

- Um ambiente de aplicativo ASP determina as configurações
para registro, rastreamento e depuração e o banco de dados
seqüência de conexão que estará em vigor quando o ASP
aplicativo é executado em uma máquina. Um desenvolvedor também pode criar
seus próprios valores de configurações que podem ser usados para dar mais
controle sobre um determinado ambiente.

- Uma variável de ambiente é um valor mantido por
o sistema operacional e pode ser usado por processos em execução
na máquina. Variáveis de ambiente gerenciadas por
Windows 10 inclui o nome do computador e o arquivo
caminhos a serem usados para procurar programas. O sistema
variável de ambiente AS PNETCORE_ENVIRONMENT pode ser definida
para valores que determinarão qual ambiente um ASP
aplicação Irá selecionar Quando começar a correr. Você pode gerenciar
a configuração dessa variável no Visual Studio, na guia Debug
da página Propriedades de um aplicativo ASP, como mostrado
Figura 4-8.

### FIGURA 4-8 Configurando a variável ASPNETCORE_ENVIRONMENT

Em aplicativos ASP.NET antigos, as configurações SQL são mantidas
arquivo web.config, que faz parte da solução. Desenvolvedores então
usar transformações XML para substituir configurações no arquivo para permitir
diferentes servidores SQL a serem selecionados.

### Operação do SQLquery

Um programa pode fazer uma consulta de um banco de dados criando
Instância do SqlCommand. O construtor de um SqlCommand é
dada uma string, que é a consulta SQL e o banco de dados
conexão, conforme mostrado na declaração da Listagem 4-19.

SqlCommand command = new SqlCommand ( "SELECT * FROM MusicTrack", connection);

A consulta é então executada como um comando do leitor (porque é
leitura do banco de dados). Esta operação retorna um
Instância Sqeader, conforme mostrado na instrução a seguir.

SqlDataR-aader reader = command. ExacuteReader (), -
O Sqeader fornece métodos que podem ser usados para mover

através dos resultados retornados pela consulta. Note que é apenas
possível avançar nos resultados. O método de leitura
move o leitor para o próximo nos resultados. A leitura
method retorna Fal 59 Quando não há mais resultados. o
itens individuais no elemento podem ser acessados usando seus
nome, como mostrado aqui.


```csharp
while (await reader.ReadAsync())
{
	string diretor = reader["Diretor"].ToString();
	string titulo = reader["Titulo"].ToString();
	Console.WriteLine("Diretor: {0} Titulo: {1}", diretor, titulo);
}
```

O primeiro comando SQL selecionou todos os elementos em uma tabela.
Você pode mudar isso para poder filtrar o conteúdo do
tabela usando uma consulta. A Listagem 4—20 mostra uma consulta que seleciona apenas
faixas de música do artista

### LISTAGEM 4-20 Filtrar com SQL

```
SELECT * FROM Diretores WHERE Nome = 'QUENTIN TARANTINO'
```

### Update data in a database

Um programa pode usar o comando SQL UPDATE para atualizar
conteúdo de uma entrada na base de dados. O comando abaixo encontra
a faixa Com o ID 1 e define o artista dessa faixa como "Robert
Milhas. "Você pode usar o ID para identificar um elemento específico em uma tabela
porque não há dois elementos com o mesmo ID. Se o ONDE
composição do comando selecionou múltiplas entradas no
banco de dados, todos eles seriam atualizados.

ATUALIZAR. MusicTrack SET Artista: 'xxx' WHERE ID = '
Quando a atualização é realizada, é possível determinar como
muitos elementos são atualizados. O programa na listagem 4-21 mostra
como isso é feito.

### LISTAGEM 4-21 Atualizar com SQL

```csharp
using (SqlConnection connection = new SqlConnection(connectionString))
{
	connection.Open();
	await ListarFilmes(connection);

	SqlCommand command = new SqlCommand(
	"UPDATE Diretores SET Nome ='QUENTIN TARANTINO' WHERE Id = 1", connection);
	int result = command.ExecuteNonQuery();

	Console.WriteLine("Número de linhas atualizadas: {0}", result);
	await ListarFilmes(connection);
}
```


### Comando de injeção de SQL e banco de dados

Suponha que você queira permitir que o usuário do seu programa atualize
o nome de uma faixa específica. Seu programa pode ler o

informações do usuário e, em seguida, construir um comando SQL
para executar a atualização. A Listagem 4—22 mostra como isso pode ser feito:

### LISTAGEM 4-22 Injeção SQL

```csharp
Console.Write("Digite o título do filme a ser alterado: ");
string titulo = Console.ReadLine();
Console.Write("Digite o novo título do filme: ");
string novoTitulo = Console.ReadLine();
string textoComando = "UPDATE Filmes SET Titulo='" + novoTitulo + "' WHERE Titulo = '" + titulo + "'";
SqlCommand command = new SqlCommand(textoComando, connection);
```


Se você executar o programa na Listagem 4—22, você descobrirá que
funciona. Você pode selecionar uma faixa por título e depois alterar
artista para essa faixa. No entanto, este é um código muito perigoso.
Considere o efeito de um usuário executando o programa e depois
digitando as seguintes informações.

Enter the title of the track to update: My Way
Enter the new artist name: Fred');

```csharp
DELETE FROM Musictrack;
```

O título da faixa é bom, mas o novo nome do artista parece bastante
estranho. O que o usuário do programa fez é injetado
outro comando SQL após o comando UPDATE. o
comando iria definir o novo nome do artista para Fred e, em seguida,
execute um comando SQL DELETE. O comando DELETE
faz exatamente o que você esperaria. Exclui todo o conteúdo
da mesa.

Isso funciona porque não há nada para parar o usuário do
programa de digitar o delimitador "(aspas simples) para marcar o
fim de uma string e, em seguida, adicionando novas instruções SQL depois disso. UMA
usuário mal-intencionado pode usar injeção SQL para assumir o controle de um
base de dados.

Por esse motivo, você nunca deve construir comandos SQL
diretamente da entrada do usuário. Você deve usar SQL parametrizado
declarações em vez disso. Listagem 4-23 mostra como eles funcionam. O SQL
comando contém marcadores que identificam os pontos na consulta
Onde o texto deve ser inserido. O programa adiciona o
valores de parâmetros que correspondem aos pontos do marcador. O SQL
servidor agora sabe exatamente onde cada elemento começa e termina,
tornando a injeção de SQL impossível.

### LISTAGEM 4-23 Consulta parametrizada

```csharp
string textoComando = "UPDATE Filmes SET Titulo = @novoTitulo WHERE Titulo = @titulo";
SqlCommand command = new SqlCommand(textoComando, connection);
command.Parameters.AddWithValue("@titulo", titulo);
command.Parameters.AddWithValue("@novoTitulo", novoTitulo);
int result = command.ExecuteNonQuery();
```

### Acesso ao banco de dados assíncrono

Os comandos SQL que usamos usaram todos
métodos síncronos para avaliar consultas e trabalhar
resultados. Existem também versões assíncronas dos métodos. Um
programa pode usar o asynq aguardar mecnamsm Wltn tnese ver51ons
dos métodos para que as consultas ao banco de dados possam ser executadas de forma assíncrona.
Isto é particularmente importante se o seu programa estiver interagindo com
o usuário Via uma interface Windowed.
O método dumpDatabase na Listagem 4-24 usa
comandos de banco de dados assíncronos para criar uma listagem do
conteúdo do banco de dados do MusicTrack. Este método é parte de um
Aplicativo WPF (Windows Presentation Foundation) que também
permite a edição de banco de dados. Note que para usar este exemplo no seu
máquina você terá que definir a seqüência de conexão do banco de dados para
faça uma conexão com um banco de dados em sua máquina.

### LISTAGEM 4-24 Acesso assíncrono

```csharp
async Task<string> dumpDatabase(SqlConnection connection)
{
	SqlCommand command = new SqlCommand("SELECT * FROM MusicTrack", connection);
	SqlDataReader reader = await command.ExecuteReaderAsync();

	StringBuilder databaseList = new StringBuilder();
	while (await reader.ReadAsync())
	{
		string id = reader["ID"].ToString();
		string artist = reader["Artist"].ToString();
		string title = reader["Title"].ToString();
		string row = string.Format("ID: {0} Artist: {1} Title: {2}", id, artist, title);
		databaseList.AppendLine(row);
	}
	return databaseList.ToString();
}
```
			
### Usando SQL em aplicativos ASP

Se você examinar o aplicativo ASP Musi cTracks que nós
criado no início da Skill 3.2, você não encontrará nenhum SQL
comandos no código que implementam as classes do controlador para
esta aplicação. Isso ocorre porque as atualizações do banco de dados em um ASP
aplicativo são executados usando um método Update que aceita
uma instância modificada da classe a ser atualizada.

Você pode ver esse comportamento em ação dando uma olhada no código
no método Edit no MusicTrackController. cs
arquivo de origem, como mostrado a seguir. A variável musiCTrack contém
a instância de faixa de música modificada, recebida da Web
Formato. A variável _context contém o contexto do banco de dados para
esta página. O código atualiza o banco de dados e captura qualquer
exceções que podem ser lançadas por esta operação.

try
{
_eontext.Update(musicTrack); // update the dat
abase context with the edited track
await _pontext.SaveChangesAsync(); // save all the
changes
catch (DbUpdateConcurrencyException)
{
// deal with exceptions


O aplicativo ASP usa o código C # incorporado na página da web

(usando um recurso chamado Razor), que itera através do
conteúdo do banco de dados e apresenta uma visão dos dados. O código
mostrado a seguir faz parte do índice. arquivo cshtml para o
Aplicação MusicTracks. O Razor permite que instruções C # sejam
inserido na descrição da página HTML para programaticamente
gerar algum conteúdo. Os elementos "Ci" na página são
precedido por um caractere @. No código a seguir você pode ver
como um loop f oreach é usado para percorrer os itens no
banco de dados e chame o método DisplayE 'ou para cada item.

@foreach (var item in Model) {
@Html.DisplayFor(modelItem => item.Art
ist)
@Html.DisplayFor(modelItem => item.Tit1e)
@Html.DisplayFor(modelItem => item.Len
9th)
id=" @ item. ID ">Edit I
id="@item.ID">Datails |
id="@item. ID">Delete
}

A Figura 4-9 mostra a saída da web gerada por esse código. Nota
que para cada item que é exibido, há também links para o
comportamentos para editar, exibir os detalhes ou excluir o item. Se você olhar
no código anterior, você pode ver que as informações de roteamento para
cada link contém o ID desse item, que é como o servidor
Vai saber qual item foi selecionado.

### FIGURA 4-9 Lista de faixas em MusicTracks

### Consumir dados JSON e XML

Você viu que é muito fácil para um programa carregar o conteúdo
de uma página web. Na Listagem 4-14 você descobriu que a classe Webclient
pode fazer isso com um único método ca11. Muitos recursos de dados são
agora fornecido para aplicações através de documentos de dados estruturados que
pode ser obtido desta maneira. Existem dois formatos populares para tal
dados, J AvaScript Object Notation (J SON) e eXtensible Markup
Linguagem (XML). Nesta seção, você verá exemplos de
cada um em uso.

Consumir dados JSON

Na Skill 3.1 na seção “Using J SON”, você viu que J SON
(JavaScript Object Notation) é um meio pelo qual as aplicações
pode trocar dados. Um documento J SON é um arquivo de texto simples que
contém uma coleção estruturada de pares de nome e valor. Você
também descobriu como ler e gravar arquivos J SON usando o
Biblioteca Newtonsoft.Json. Leia essa seção novamente para atualizar
sua memória sobre J SON antes de continuar Com esta seção.
O programa na Listagem 4-25 consome um feed J SON fornecido
pela Administração Nacional de Aeronáutica e Espaço (NASA).

O feed é atualizado todos os dias com uma nova foto ou vídeo de
os arquivos da NASA. O método getImageO f Day retorna um
Objeto que descreve a imagem do dia para um endereço específico 011
o site da NASA. Ele usa as bibliotecas Newtonsoft descritas em
Habilidade 3.1 para converter o texto carregado da página web da NASA em
uma instância da classe ImageOfDay com todos os campos
inicializado.

### Listagem 4-25 NASA JSON

```csharp
public class ImageOfDay
{
	public string date { get; set; }
	public string explanation { get; set; }
	public string hdurl { get; set; }
	public string media_type { get; set; }
	public string service_version { get; set; }
	public string title { get; set; }
	public string url { get; set; }

	async Task<ImageOfDay> GetImageOfDay(string imageURL)
	{
		string NASAJson = await readWebpage(imageURL);
		ImageOfDay result = JsonConvert.DeserializeObject<ImageOfDay>(NASAJson);
		return result;
	}

}
```

Para que isso funcione eu tive que criar uma classe ImageOfDay que
corresponde exatamente ao objeto descrito pelo feed J SON de
NASA Uma maneira de fazer isso é usar o site
http: // json2 <: sharp.com. Qual aceitará um endereço da web que
retorna um documento J SON e, em seguida, gera automaticamente um C #
classe conforme descrito no documento.
O código que exibe a imagem Quando o usuário clica em um botão
para executar a carga é mostrado a seguir. O método di SplayUrl
carrega de forma assíncrona a imagem e a exibe na tela.
O código também obtém o texto descritivo da imagem e exibe
em uma caixa de texto.

private async void LoadButtclicked (object sender, R0
utedEventI-Lrgs e)
{
try
{
ImageCfDay imageCfDay = await getImageOfDay(
"https : //api . nasa . gov/planatary/apcd
api_key=DEMC_KZY&date=2 0 18—0 5-2 9 ") ;

if (imageOfDay.media_type != "image")
{
Messagec.Show(“It is not an image today"
) ;
return;
}
DescriptionTextBlock.Text = imageOfDay.explana
tion;
await displayUrl(imageOfDay.url);
}
catch (Exception ex)
{
Messagec.Show("Fetch failed: {0}", ex.Messag
8) ;
}

O programa funciona bem, embora no momento seja sempre
mostra a mesma imagem, que é especificada no endereço no
código anterior. Seria fácil modificar o programa para exibir
a imagem para um dia em particular. Note que o programa usa um
demo .API para obter acesso ao site da NASA. Isso só pode ser

usado para alguns downloads por hora. Se você quiser usar este serviço
Para o seu aplicativo, você pode solicitar uma chave de API gratuita da NASA.
A figura 4-10 mostra a saída do programa.

### Consumir dados XML

Na Skill 3.1, na seção “JSON e XML”, exploramos o
diferença entre J SON e XML. A linguagem XML é
ligeiramente mais expressivo que J SON, mas documentos XML são
maior do que o equivalente J SON documentos e isso, juntamente com o
facilidade de uso de J SON, levou a J SON a substituir XML. No entanto, um
Muitas informações ainda são expressas usando XML. Na Skill 3.1 nós
viu um documento XML que descreveu uma instância do MusicTrack.

(MusicTrack xmlns:xsi="http://www.w3.org/2001/XMLSchem
a-instance" xmlns:xsd="http://www.w3.org/200l/XMLSchema"
>Rob Mile3
150

Uma maneira de consumir esse documento é trabalhar em cada
elemento por sua vez. O sistema . Namespace XML contém um conjunto de
classes para trabalhar com documentos XML. Uma dessas classes é
a classe XMLTextReader. Uma instância do XMLTextReader
class Irá trabalhar através de um fluxo de texto e decodificar cada XML
elemento por sua vez.
O programa na Listagem 4-26 mostra como isso é feito. Ele cria
um fluxo StringReader usado para construir um
XMLTextReader. O programa então percorre cada um dos
Elementos XML que são lidos a partir do fluxo, imprimindo
informação do elemento.

### LISTAGEM 4-26 Elementos XML

```csharp
string xmlDocument =
	"<Filme>" +
		"<Diretor>Quentin Tarantino</Diretor>" +
		"<Titulo>Pulp Fiction</Titulo>" +
		"<Minutos>154</Minutos>" +
	"</Filme>";

using (StringReader stringReader = new StringReader(xmlDocument))
{
	XmlTextReader reader = new XmlTextReader(stringReader);
	while (reader.Read())
	{
		string description = string.Format("Type: {0} Name: {1} Value: {2}",
			reader.NodeType.ToString(), reader.Name, reader.Value);
		Console.WriteLine(description);
	}
}
```			

A saída deste programa fornece cada item como

Type:XmlDeclaration Namezxml Valua:version="l.0" encoding="utf—l6"
Typezilement NamezMusicTrack Value:
Type:White3pace Name: Value:
Type:Element Namezrtist Value:
Type:Text Name: Valuez
Type:2ndElement NamazArtist Value:
Type:Whitespace Name: Value:
Type:Element Namezfitla Value:
Type:Text Name: Value:My Way
Type:EndElament Name:Title Value:
Type:Whitespace Name: Value:
Type:Element Name:Length Value:
Type:Taxt Name: Value:150
Type:EndElement Name:Length Value:
Type:EndElement Nama:Mu3icTrack Value:
XML do cuments

É possível ler informações de um documento XML por
decodificação de cada elemento individual, mas isso pode ser um trabalho difícil
código. Uma abordagem mais fácil é usar uma instância do documento XMLDo.
Isso cria um Document Object Model (DOM) na memória de
Quais dados podem ser extraídos. Outra vantagem de um DOM é que
um programa pode alterar elementos no DOM e, em seguida, escrever um
cópia modificada do documento incorporando as alterações.
O programa na Listagem 4-27 cria um DoCar Xml
instância de uma string de XML descrevendo um icTrack Mus e
Em seguida, lê as informações do artista e título dele. O programa
verifica para ter certeza de que o documento descreve um MusicTrack
antes de escrever a informação.

### LISTING 4-27 XML DOM

```csharp
string xmlDocument =
	"<Filme>" +
		"<Diretor>Quentin Tarantino</Diretor>" +
		"<Titulo>Pulp Fiction</Titulo>" +
		"<Minutos>154</Minutos>" +
	"</Filme>";

XmlDocument doc = new XmlDocument();
doc.LoadXml(xmlDocument);

var rootElement = doc.DocumentElement;

// garantindo que é um elemento válido
if (rootElement.Name != "Filme")
{
	Console.WriteLine("Não é um filme!");
}
else
{
	string diretor = rootElement["Diretor"].FirstChild.Value;
	Console.WriteLine("", diretor);
	string titulo = rootElement["Titulo"].FirstChild.Value;
	Console.WriteLine("Diretor: {0} \r\nTitulo: {1}", diretor, titulo);
}
```

Um XmlDocument contém uma hierarquia de itens com um
rootElement objeto o topo da hierarquia. Um programa pode
acessar itens em um elemento usando um indexador de string que
contém o nome do item requerido. Na próxima seção nós
descobrirá como usar o Language Integrated Queries (LINQ) para
trabalhe com XML do cuments.

Recuperar dados usando o WindowsCommunicationFoundation (WCF)
Você já viu como um aplicativo pode consumir dados
de um serviço usando uma solicitação HTTP para baixar um J SON ou
Documento XML. O leitor de imagens da NASA na Listagem 4—2 5 funciona
convertendo uma resposta de um servidor em uma instância de uma classe
que contém uma descrição da imagem e o endereço da web
de onde a imagem pode ser baixada. Para usar o
informações fornecidas pelo servidor da NASA, um programa cliente
contém uma classe C # que corresponde ao documento J SON que é
recebido do servidor.
Um cliente de um serviço da Web também usa uma instância de um objeto para
interaja com um servidor. No entanto, nesse caso, o cliente pode chamar
métodos no objeto para ler dados e também atualizar informações
no servidor. O objeto criado é chamado de "objeto proxy".
Uma chamada para um método no objeto proxy fará com que uma solicitação seja
criado que é enviado para o serviço no servidor.

Quando o servidor recebe a solicitação, ele chama o método
código em um objeto do servidor. O resultado a ser retornado pelo método
Será então empacotado em outra mensagem de rede, que é
enviado de volta para o cliente e, em seguida, envia o valor de retorno de volta para
o software de chamada. Não se preocupe sobre como as mensagens são
construído e transferido. Você só precisa criar um servidor
métodos e chamadas dos sistemas do cliente.
O serviço também expõe uma descrição dos métodos que ele
fornece. Isso é usado pela ferramenta de desenvolvimento (no nosso caso
Visual Studio) para realmente criar o objeto proxy no cliente
programa. Isso significa que você pode criar facilmente um cliente
aplicação.

### Crie um serviço da web

Para descobrir como tudo isso funciona, vamos criar uma "piada do dia"
serviço. Isso retornará uma string contendo algo adequadamente
cócegas de costela a pedido do cliente. O usuário será capaz de
selecione a "força" da piada, variando de 0 a 2, onde 0 é
levemente divertido e 2 é um rolo garantido no chão rindo
experiência.

O aplicativo será composto de duas partes, o servidor
programa que exporta o serviço e o programa cliente que
usa isso. O servidor é criado como um WCF (Windows
Communication Foundation) Aplicativo de serviço. O cliente Will
ser um aplicativo que se conecta ao serviço e solicita uma
gracejo.
O código a seguir mostra o método único que é fornecido pelo
serviço. Isso faz parte do código no aplicativo do servidor. o
O método getJo ke aceita um inteiro e retorna uma string de texto.
Os atributos [ServiceCentract] e
[OperationContract] denota que a interface e o método
devem ser expostos como serviços.

```csharp
[ServiceContract]
public interface IMeuServico
{
	[OperationContract]
	string GetValor(int chave);
}
```

Depois de ter a interface, você precisa agora de uma classe que
implementa o método. Este método irá fornecer o serviço
que a interface descreve. Como você pode ver no código a seguir,
o método é bem simples, e as piadas também. A entrada
O parâmetro é usado para selecionar uma das três strings de piada e retorná-la.
Se não houver correspondência para a entrada, a string "Força inválida" é
retornou.

Se você criar um serviço, poderá usar o Cliente de Teste do WCF para
invoque os métodos e visualize os resultados. Esta ferramenta permite que você ligue
métodos no serviço e ver os resultados que eles retornam. Figura
4—11 mostra o cliente de teste em uso. Você pode ver os resultados de uma chamada para
o método Com um parâmetro de 1.

GI t Yen cum: - D X
E“! 100“ 311'
eBl-yScnte Pm ‘ MM:
8 ’6 WIIWSUMWWMIM
$12 Wcmmtc [mmsh‘ aw.“
i 42’ 2:33am!) Mme Vabe Type
"0 Cody m )ckgrmh I 5911t
Ramme- D Mammary [E
Nam \‘abc Tm
cram] ”maxi men and Ne, we got Spam Sim;
¢ ' > Fandled ”'1
Servize iwomian completed. a;

### FIGURA 4-11 Cliente de teste do WCF

Você também pode ver a descrição do serviço em um navegador como
mostrado na Figura 4-12. Isso dá um link para a descrição do serviço, como
bem algum código de exemplo que mostra como usá-lo.

### FIGURA 4-12 Descrição do serviço em um navegador

### Joke of the Day Client

O aplicativo cliente pode ser executado em qualquer máquina que tenha uma rede
conexão e quer consumir o serviço. O aplicativo cliente
precisa conter uma conexão com o JokeOfTheDayService. este
é adicionado ao projeto Visual Studio do cliente como uma referência como qualquer outro, usando a solução
Painel do Explorer no Visual Studio. Clique com o botão direito do mouse nas Referências
item e selecione Adicionar Referência de Serviço no contexto
menu, conforme mostrado na Figura 4–13.

### FIGURA 4-13 Adicionando um novo serviço

Neste ponto, o Visual Studio precisa encontrar a descrição do
serviço que deve ser usado. A caixa de diálogo Add Service Reference
permite que você digite o endereço de rede de um serviço e o Visual
O Studio então lerá a descrição do serviço fornecida pelo
serviço. A Figura 4-14 mostra a caixa de diálogo usada para configurar o cliente.
Você pode ver que o serviço Jo keOfTheDay fornece apenas um
método. Na parte inferior desta caixa de diálogo, você pode ver o namespace
que você deseja que o serviço tenha no aplicativo cliente.
Altere esse nome para JokeofTheDayService.

### FIGURA 4-14 Adicionando um novo serviço

Uma vez que o serviço foi adicionado, ele agora ocupa o lugar
solução. Nosso aplicativo deve agora criar um objeto proxy que
Será usado para invocar os métodos no serviço. O código a seguir
cria uma instância de serviço e chama o método GetJoke para obter um
piada do serviço. Observe que a solução de exemplo para listagem
4-28 contém dois projetos do Visual Studio. Um implementa o
servidor eo outro o cliente.

### LISTAGEM 4-28 Serviço da Web

```csharp
using (MeuServicoClient servicoClient = new MeuServicoClient())
{
	Console.WriteLine(servicoClient.GetValor(1));
}
Console.ReadKey();
```
