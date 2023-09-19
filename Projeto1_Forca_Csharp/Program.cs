using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection; // usado para o metodo DictPath na classe DictIO


class Program
{
    static void Main()
    {
        //Words dicionario = new Words(); //DESNECESSARIO???
        UserScreen telaUsuario = new UserScreen(); // instancia objeto para gerar tela visualizada pelo usuario
        // essa tela de usuario deveria ser melhorada, poderia ser usada sempre a mesma tela, alterando apenas as linhas necessarias conforme necessidade,
        // /\ não feito por falta de tempo
        Console.ForegroundColor = ConsoleColor.Cyan; //seleciona cor do texto
        DictIO dictIOManager = new DictIO(); // objeto para escrever / ler arquivo externo (base de dados csv)
        dictIOManager.DictIOReader(); // Lendo o dicionário (base de dados csv) usando o objeto acima
        
     
        
        Console.Clear(); //limpa a tela

        while (true) //mantem programa rodando indefinidamente, até ser fechado / interrompido pelo usuario
        {
            Console.ForegroundColor = ConsoleColor.Cyan; // ajusta a cor para casos em que a cor foi alterada para algumas "telas"
            
            try // para pegar possiveis inputs indesejados
            
            {               
                char input1 = UserScreen.InitialScreen(); //chama tela inicial, retorna o input do usuario opções de jogar ou cadastrar nova palavra
                
                if (input1 == '1') // 1 = jogar agora
                {
                    GameScreen telaJogo = new GameScreen(); // cria nova tela no console, onde está a lógica do jogo
                }

                else if (input1 == '2')  // 2 = cadastrar palavra nova
                {
                   
                    List<string> cadastro = UserScreen.RegistryScreen(); //chamando metodo de cadastro, que retorna uma lista contendo palavra[0] e dica[1]
                    Words.AddWord(cadastro[0], cadastro[1]); // método addword adiciona entrada ao dicionario (base de dados dentro do programa)
                               
                    dictIOManager.DictIOWriter(); // método para escrever dados do dict no arquivo de base de dados                              
                    
                }
                else
                {
                    throw new FormatException(); // entradas invalidas geram nova exceçao
                }
                
            }
            catch (FormatException)
            {
                // cria uma nova tela para alertar sobre opçao invalida.
                // Essa parte é um exemplo do que poderia ser melhorado como dito acima, pois só 2 linhas precisariam alteração
                // cada linha é uma linha na tela. Não posso retirar ou adicionar linhas para não causar distorções da maneira que está
                Console.Clear(); 
                Console.ForegroundColor = ConsoleColor.Red; 
                telaUsuario.CenterText("", starter: '╔', sep: '═', ends: '╗');
                telaUsuario.CenterText(""); 
                telaUsuario.CenterText("Opção inválida! Digite uma das opções disponíveis!");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("Aperte qualquer tecla para voltar a tela inicial.");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText(" ┌───────┐ ");
                telaUsuario.CenterText(" │       O ");
                telaUsuario.CenterText(" │      /|\\ ");
                telaUsuario.CenterText(" │      / \\ ");
                telaUsuario.CenterText("  │     ┌───┐ ");
                telaUsuario.CenterText(" _│_    │   │ ");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("", starter: '╚', sep: '═', ends: '╝');
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(52, 18); // posiciona cursor dentro do [ ]
                Console.ReadKey(); // mantem o programa pausado ate uma tecla qualquer ser apertada

            }
            catch (ArgumentNullException) // caso usuario aperte enter sem nenhum caractere, esta exceçao e gerada
            {
                Console.Clear(); 
                Console.ForegroundColor = ConsoleColor.Red;
                telaUsuario.CenterText("", starter: '╔', sep: '═', ends: '╗');
                telaUsuario.CenterText(""); 
                telaUsuario.CenterText("Digitação obrigatória!");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("Aperte qualquer tecla para voltar a tela inicial.");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText(" ┌───────┐ ");
                telaUsuario.CenterText(" │       O ");
                telaUsuario.CenterText(" │      /|\\ ");
                telaUsuario.CenterText(" │      / \\ ");
                telaUsuario.CenterText("  │     ┌───┐ ");
                telaUsuario.CenterText(" _│_    │   │ ");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("", starter: '╚', sep: '═', ends: '╝');
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(52, 18);
                Console.ReadKey();

            }
            catch (ArgumentException) // caso o usuario tente cadastrar uma nova palavra que ja esta no dicionario ativo no programa...
            {
                Console.Clear(); 
                Console.ForegroundColor = ConsoleColor.Red;
                telaUsuario.CenterText("", starter: '╔', sep: '═', ends: '╗');
                telaUsuario.CenterText(""); 
                telaUsuario.CenterText("Palavra já cadastrada!");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("Aperte qualquer tecla para voltar a tela inicial.");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText(" ┌───────┐ ");
                telaUsuario.CenterText(" │       O ");
                telaUsuario.CenterText(" │      /|\\ ");
                telaUsuario.CenterText(" │      / \\ ");
                telaUsuario.CenterText("  │     ┌───┐ ");
                telaUsuario.CenterText(" _│_    │   │ ");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("");
                telaUsuario.CenterText("", starter: '╚', sep: '═', ends: '╝');
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(52, 18);
                Console.ReadKey();

            }
            
        }
    }

    class UserScreen // classe da tela do usuário / tela do programa
    {
        //public UserScreen() //inicializa a classe da tela de usuário (metodo construtor, aparentemente desnecessario apos remoçao de elementos daqui. deixei aqui caso ocorra problemas )
        //{        
        //}
        
          public static char InitialScreen() //cria tela inicial
          {
           
            UserScreen tela1 = new UserScreen(); // cria uma nova tela padrão / novo objeto usando a classe UserScreen
            // aqui é onde acredito que teria sido uma melhor opção criar cada linha como argumento, ou como método.
            // Assim teria sido mais fácil para alterar cada linha no restante do codigo
            //metodo CenterText serve para imprimir centralizado, mais explicações no metodo

            Console.Clear(); 
            tela1.CenterText("", starter:'╔', sep:'═', ends:'╗');
            tela1.CenterText(""); 
            tela1.CenterText("JOGO DA FORCA");
            tela1.CenterText("");
            tela1.CenterText("");
            tela1.CenterText("[1] Jogar agora");
            tela1.CenterText("");
            tela1.CenterText("[2] Cadastrar palavra");
            tela1.CenterText("");
            tela1.CenterText("");
            tela1.CenterText(">>>>> [ ] <<<<<");
            tela1.CenterText("");
            tela1.CenterText("");
            tela1.CenterText(" ┌───────┐ ");
            tela1.CenterText(" │       O ");
            tela1.CenterText(" │      /|\\ ");
            tela1.CenterText(" │      / \\ ");
            tela1.CenterText("  │     ┌───┐ ");
            tela1.CenterText(" _│_    │   │ ");
            tela1.CenterText("");
            tela1.CenterText("");
            tela1.CenterText("", starter:'╚', sep:'═', ends:'╝');
           
            Console.SetCursorPosition(52, 10); //posicionamento do cursor para input
            char userOption = char.ToUpper(Console.ReadKey().KeyChar); //variavel com a selecao do usuario. ReadKey aqui serve para receber a primeira tecla do input do usuario,
                                                                       //e KeyChar passa o valor recebido em formato ´char´para a variavel userOption

            return userOption;
          }

          public static List<string> RegistryScreen() //cria tela para cadastrar palavras
          {
            labelInicioTelaCadastro:
            UserScreen telaCadastro = new UserScreen(); // cria uma nova tela / novo objeto para solicitar palavra
            
            Console.Clear(); 
            telaCadastro.CenterText("", starter:'╔', sep:'═', ends:'╗');
            telaCadastro.CenterText(""); 
            telaCadastro.CenterText("CADASTRAR PALAVRA NO JOGO");
            telaCadastro.CenterText("");
            telaCadastro.CenterText("DIGITE CATEGORIA (DICA) DA PALAVRA:");
            telaCadastro.CenterText("[                                  ]");
            telaCadastro.CenterText("");
            telaCadastro.CenterText("DIGITE PALAVRA PARA ADICIONAR:");
            telaCadastro.CenterText("[                                  ]");
            telaCadastro.CenterText("");
            telaCadastro.CenterText("");
            telaCadastro.CenterText("");
            telaCadastro.CenterText("");
            telaCadastro.CenterText(" ┌───────┐ ");
            telaCadastro.CenterText(" │       O ");
            telaCadastro.CenterText(" │      /|\\ ");
            telaCadastro.CenterText(" │      / \\ ");
            telaCadastro.CenterText("  │     ┌───┐ ");
            telaCadastro.CenterText(" _│_    │   │ ");
            telaCadastro.CenterText("");
            telaCadastro.CenterText("");
            telaCadastro.CenterText("", starter:'╚', sep:'═', ends:'╝');
            
            Console.SetCursorPosition(36, 5);
            string dica = Console.ReadLine().ToUpper();
            if (dica == "")
            {
                throw new ArgumentNullException();
            }

           //tela para solicitar palavra:
            Console.Clear(); 
            telaCadastro.CenterText("", starter:'╔', sep:'═', ends:'╗');
            telaCadastro.CenterText(""); 
            telaCadastro.CenterText("CADASTRAR PALAVRA NO JOGO");
            telaCadastro.CenterText("");
            telaCadastro.CenterText("DIGITE CATEGORIA (DICA) DA PALAVRA:");
            telaCadastro.CenterText($"[{dica}]");
            telaCadastro.CenterText("");
            telaCadastro.CenterText("DIGITE PALAVRA PARA ADICIONAR:");
            telaCadastro.CenterText("[                                  ]");
            telaCadastro.CenterText("");
            telaCadastro.CenterText("");
            telaCadastro.CenterText("");
            telaCadastro.CenterText("");
            telaCadastro.CenterText(" ┌───────┐ ");
            telaCadastro.CenterText(" │       O ");
            telaCadastro.CenterText(" │      /|\\ ");
            telaCadastro.CenterText(" │      / \\ ");
            telaCadastro.CenterText("  │     ┌───┐ ");
            telaCadastro.CenterText(" _│_    │   │ ");
            telaCadastro.CenterText("");
            telaCadastro.CenterText("");
            telaCadastro.CenterText("", starter:'╚', sep:'═', ends:'╝');

            Console.SetCursorPosition(36, 8);
            string palavra = Console.ReadLine().ToUpper();
            if (palavra == "")
            {
                throw new ArgumentNullException();
            }
            
            //tela de confirmação:
            Console.Clear(); 
            telaCadastro.CenterText("", starter:'╔', sep:'═', ends:'╗');
            telaCadastro.CenterText(""); 
            telaCadastro.CenterText("CADASTRAR PALAVRA NO JOGO");
            telaCadastro.CenterText("");
            telaCadastro.CenterText("DIGITE CATEGORIA (DICA) DA PALAVRA:");
            telaCadastro.CenterText($"[{dica}]");
            telaCadastro.CenterText("");
            telaCadastro.CenterText("DIGITE PALAVRA PARA ADICIONAR:");
            telaCadastro.CenterText($"[{palavra}]");
            telaCadastro.CenterText("");
            telaCadastro.CenterText(">>>>> [ ] <<<<<");
            telaCadastro.CenterText("[C] PARA CONFIRMAR || [R] REESCREVER");
            telaCadastro.CenterText("");
            telaCadastro.CenterText(" ┌───────┐ ");
            telaCadastro.CenterText(" │       O ");
            telaCadastro.CenterText(" │      /|\\ ");
            telaCadastro.CenterText(" │      / \\ ");
            telaCadastro.CenterText("  │     ┌───┐ ");
            telaCadastro.CenterText(" _│_    │   │ ");
            telaCadastro.CenterText("");
            telaCadastro.CenterText("");
            telaCadastro.CenterText("", starter:'╚', sep:'═', ends:'╝');

            Console.SetCursorPosition(52, 10);
            char opcao = char.ToUpper(Console.ReadKey().KeyChar); //variavel com a selecao do usuario

            if (dica.All(char.IsLetter) && palavra.All(char.IsLetter))
            { // tentando aprender a usar redirecionamento "goto"
                if (opcao == 'R')
                {
                    goto labelInicioTelaCadastro;
                }
                else if (opcao == 'C')
                {
                    goto labelRetornoCadastro;
                }

                else // se a tecla digitada nao for uma das opçoes acima, retorna mensagem de erro
                {
                    Console.Clear(); 
                    Console.ForegroundColor = ConsoleColor.Red;
                    telaCadastro.CenterText("", starter: '╔', sep: '═', ends: '╗');
                    telaCadastro.CenterText(""); 
                    telaCadastro.CenterText("Opção Inválida!");
                    telaCadastro.CenterText("");
                    telaCadastro.CenterText("");
                    telaCadastro.CenterText("Aperte qualquer tecla para continuar.");
                    telaCadastro.CenterText("");
                    telaCadastro.CenterText("");
                    telaCadastro.CenterText("");
                    telaCadastro.CenterText("");
                    telaCadastro.CenterText("");
                    telaCadastro.CenterText("");
                    telaCadastro.CenterText("");
                    telaCadastro.CenterText(" ┌───────┐ ");
                    telaCadastro.CenterText(" │       O ");
                    telaCadastro.CenterText(" │      /|\\ ");
                    telaCadastro.CenterText(" │      / \\ ");
                    telaCadastro.CenterText("  │     ┌───┐ ");
                    telaCadastro.CenterText(" _│_    │   │ ");
                    telaCadastro.CenterText("");
                    telaCadastro.CenterText("");
                    telaCadastro.CenterText("", starter: '╚', sep: '═', ends: '╝');
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(52, 18);
                    Console.ReadKey(); // aqui serve apenas para aguardar usuario apertar qualquer tecla (menos a "tecla qualquer")

                    goto labelInicioTelaCadastro;
                }
            }
            else // caso usuario digite algum numero, ou outros caracteres invalidos
            {
                Console.Clear(); 
                Console.ForegroundColor = ConsoleColor.Red;
                telaCadastro.CenterText("", starter: '╔', sep: '═', ends: '╗');
                telaCadastro.CenterText(""); 
                telaCadastro.CenterText("Palavra e/ou dica inválida(s)!");
                telaCadastro.CenterText("");
                telaCadastro.CenterText("");
                telaCadastro.CenterText("Aperte qualquer tecla para continuar.");
                telaCadastro.CenterText("");
                telaCadastro.CenterText("");
                telaCadastro.CenterText("");
                telaCadastro.CenterText("");
                telaCadastro.CenterText("");
                telaCadastro.CenterText("");
                telaCadastro.CenterText("");
                telaCadastro.CenterText(" ┌───────┐ ");
                telaCadastro.CenterText(" │       O ");
                telaCadastro.CenterText(" │      /|\\ ");
                telaCadastro.CenterText(" │      / \\ ");
                telaCadastro.CenterText("  │     ┌───┐ ");
                telaCadastro.CenterText(" _│_    │   │ ");
                telaCadastro.CenterText("");
                telaCadastro.CenterText("");
                telaCadastro.CenterText("", starter: '╚', sep: '═', ends: '╝');
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(52, 18);
                Console.ReadKey();
                goto labelInicioTelaCadastro;
            }             
            
           
            labelRetornoCadastro:
            List<string> retorno = new List<string> { palavra, dica }; //retornando uma llista para passar como parametros ao adicionar nova palavra ao dicionario
            return retorno;

        }
        // cria um texto centralizado, usado para montar a tela no console, aceitando como argumentos:
        // "text = texto a ser exibido"
        //" starter = primeiro caractere da linha",
        // "ends = ultimo caractere da linha",
        // "sep = caracter para usar como separador, que aparecerá antes e depois do texto até o tamanho da tela",
        // "width = largura" 
        // Todos os parâmetros são opcionais, e com valores padrão criam linhas com margem nas laterais
        // Caracteres para usar como starter / ends / sep:{ ╔ ╗ ╚ ╝ ═ } Com estes é possível montar linhas do topo e do final
        public void CenterText(string text = "", char starter = '║', char ends = '║', char sep = ' ', int width = 100) 
                {   
                    int padWidth = (width - text.Length) / 2; // encontra a metade da largura, excluindo o tamanho do texto criado
                    string paddedText = text.PadLeft(text.Length + padWidth, sep).PadRight(width, sep); // PadLeft e PadRight criam caracteres de preenchimento "sep" em ambos os lados do texto, deixando centralizado na tela  
                    Console.WriteLine("  " + starter + paddedText + ends + "  "); // cria o texto centralizado na tela usando starter e ends como margem
                                            
                }

    
    }

    class GameScreen // Classe usada para separar a tela do jogo das demais, apesar de usar a classe UserScreen para gerar as linhas, acredito ser melhor para entendimento
    {

        public GameScreen()
        {            
            UserScreen telaJogo = new UserScreen(); // cria nova tela usando a classe UserScreen
            Console.ForegroundColor = ConsoleColor.Cyan;
            int lives = 5; // controla vidas ou tentativas disponíveis
            //string coracao = "\u2764"; //versão com corações. não suportado no console visual studio
            string coracao = "|";
            int finalizar = 0; //
            List<string> palavraChave= Words.GetWord(); //busca uma palavra aleatoria no dicionario, retorna palavra a ser escondida e a dica em formato de lista
            int wordLength = palavraChave[0].Length; // tamanho da palavra chave
            string palavraEscondida = palavraChave[0]; // recebe palavra chave da lista
            string[] palavraAtual = new string[wordLength]; // inicia uma array com o tamanho da palavra chave. 
            List<string> usedLetters = new List<string>(); // lista para mostrar letras já usadas
            string usedLettersSTR = ""; // inicia uma string onde serão adicionadas as letras já digitadas durante o jogo
            for (int i = 0; i < palavraAtual.Length; i++) // usando o tamanho da array como quantidade de loops..
            {
                palavraAtual[i] = "_"; // .. substitui cada elemento da array por - para ser visto na tela, enquanto a letra não foi acertada
            }            
            bool keepLoop = true; // controle de loop
            // linhas substituidas na tela principal, o loop abaixo manterá as linhas sem alteração ativas
            string linha4 = Words.wordReplacer("");            
            string linha11 = Words.wordReplacer($"DICA: {palavraChave[1]}");
            string linha12 = Words.wordReplacer("");
            string linha14 = Words.wordReplacer(" │         ");
            string linha15 = Words.wordReplacer(" │          ");
            string linha16 = Words.wordReplacer(" │          ");
            string linha17 = Words.wordReplacer("  │     ┌───┐ ");
            string linha18 = Words.wordReplacer(" _│_    │   │ ");
            string linha19 = Words.wordReplacer("");
            
            while (keepLoop) // loop com a tela do jogo
            {
                Console.Clear(); 
                if (lives == 1 && finalizar == 0) // manter amarelo enquanto estiver com ultima vida, e antes de finalizar
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow; // ..amarelo para alertar da ultima chance
                    }
                // criação da tela
                telaJogo.CenterText("", starter: '╔', sep: '═', ends: '╗');
                telaJogo.CenterText(""); 
                telaJogo.CenterText("BEM VINDO(A) AO JOGO DA FORCA");
                telaJogo.CenterText("");
                telaJogo.CenterText("ESCOLHA UMA LETRA");
                telaJogo.CenterText("");
                Console.WriteLine(linha4);
                telaJogo.CenterText("[ ]");
                string palavraAtualConcat = string.Concat(palavraAtual); // juntando os elementos da array em 1 string
                // a linha abaixo usa wordReplacer para escrever a palavra dentro, e CenterText para criar as margens padrão
                telaJogo.CenterText(Words.wordReplacer(text: palavraAtualConcat, sep: '-', width: wordLength, starter: ' ', ends: ' '));
                string livesSTR = new string(coracao[0], lives); // criando strings com o numero de vidas vezes o caractere "coracao"
                telaJogo.CenterText($"TOTAL DE LETRAS: {wordLength}, VIDAS:{livesSTR}");
                telaJogo.CenterText("");
                Console.WriteLine(linha11);
                Console.WriteLine(linha12);
                telaJogo.CenterText(" ┌───────┐ ");
                Console.WriteLine(linha14);
                Console.WriteLine(linha15);
                Console.WriteLine(linha16);
                Console.WriteLine(linha17);
                Console.WriteLine(linha18);
                Console.WriteLine(linha19);
                telaJogo.CenterText("");
                telaJogo.CenterText("", starter: '╚', sep: '═', ends: '╝');

                if (lives <= 0 || finalizar == 1) //condicional para encerrar o jogo quando as vidas são zeradas ou "finalizar" é ativado
                {

                labelFinalizar:                    
                    Console.SetCursorPosition(52, 7);
                    ConsoleKeyInfo final = Console.ReadKey();
                    if (final.Key == ConsoleKey.Q || final.Key == ConsoleKey.S) // usado aqui para testar formas de capturar input especifico
                    {
                        break; // se usuario selecionar uma das teclas solicitadas, sai do loop atual, retornando ao loop da tela de inicio
                    }
                    else
                    {
                        goto labelFinalizar; // retorna ao inicio do bloco apenas para manter ativo ate usuario selecionar s ou q
                    }


                }

                Console.ForegroundColor = ConsoleColor.Cyan; // retorna a cor original
                
                labelLetterInput:                
                Console.SetCursorPosition(52, 7);
                ConsoleKeyInfo tecla = Console.ReadKey(); //Readkey le a ultima tecla digitada, para impedir varios inputs
                char letraInput = tecla.KeyChar; // keychar passa o valor de readkey / consolekeyinfo para char. Nomes diferentes para nao confundir
                letraInput = char.ToUpper(letraInput); // apenas passando para maiusculo
                string letraInputSTR = letraInput.ToString(); // convertendo input para string para uso diferente do char abaixo

                Console.SetCursorPosition(52, 7);
                
                if (usedLetters.Contains(letraInputSTR)) //checa se letra já foi usada..
                {
                    goto labelLetterInput; // ..se sim, volta ao bloco acima, na pratica, apenas mantem o cursor no mesmo lugar 
                                            // evita problemas com contagem das vidas
                }

                if (char.IsLetter(letraInput)) // caso o char digitado seja uma letra ..
                {
                    usedLetters.Add(letraInputSTR); //.. adicionando a string da letra escolhida para a lista de strings com as letras ja usadas
                    usedLettersSTR = string.Join(", ", usedLetters); // .. juntando os elementos da lista em 1 string, separados por ,
                    linha4 = Words.wordReplacer($"LETRAS JÁ USADAS: [{usedLettersSTR}]"); // retorna string com as letras já usadas
                }
                
                else // se não for letra, volta ao inicio do bloco, na pratica mantendo o cursor no mesmo lugar até receber input valido
                {                    
                    goto labelLetterInput; 
                }
                           
                 labelContinuation1: // continuaçao depois das veriicacoes acima               


                if (palavraEscondida.Contains(letraInput))
                {
                    //int indexCounter = 0;
                    for (int i = 0; i < palavraEscondida.Length; i++) //percorre a palavraEscondida, 1 caractere por vez, até o tamanho (Length) da palavra em si
                    {
                        if (palavraEscondida[i] == letraInput) // checando se o Input (char) é igual a letra[i] dentro da palavraEscondida
                        {
                            palavraAtual[i] = letraInputSTR; // caso seja igual, adiciona ao Array palavraAtual, no índice correspondente àquela letra na palavra
                            linha12 = Words.wordReplacer($"PALAVRA CONTÉM LETRA {letraInputSTR}");
                        }
                                                
                    }
              
                    if (palavraAtual.Contains("_")) //checando a presença do _ na array palavraAtual
                    {
                        ; // caso ainda exista algum _, o código continua
                    }
                    else //caso não exista mais nenhum _, significa que a palavra foi finalizada, e o jogo ganho
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        linha12 = Words.wordReplacer("PARABÉNS, VOCÊ ACERTOU A PALAVRA!");
                        linha14 = Words.wordReplacer(" │         ");
                        linha15 = Words.wordReplacer(" │          ");
                        linha16 = Words.wordReplacer("      │            \\O/");
                        linha17 = Words.wordReplacer("     │     ┌───┐   │");
                        linha18 = Words.wordReplacer("     _│_    │   │  / \\");
                        linha19 = Words.wordReplacer("APERTE [S] OU [Q] PARA SAIR");
                                                
                        finalizar = 1; // ativa finalização do loop / tela do jogo
                        
                    }

                }                  
                                    
                else // caso não tenha a letra, retira 1 vida e preenche o desenho
                {
                    lives -= 1; // Diminui 1 vida a cada erro
                    Console.SetCursorPosition(0, 12);
                    linha12 = Words.wordReplacer("A LETRA DIGITADA NÃO EXISTE NA PALAVRA-CHAVE!");
                    Console.SetCursorPosition(52, 7);
                    
                    // linhas substituidas para cada vida perdida
                    if (lives == 4)
                    {                        
                        // linha14 = Words.wordReplacer(" │       😐 "); //versao emoji - Nao suportada no console do visual studio
                        linha14 = Words.wordReplacer(" │       O ");
                        linha12 = Words.wordReplacer("A LETRA DIGITADA NÃO EXISTE NA PALAVRA-CHAVE!");

                    }
                    else if (lives == 3)
                    {                                               
                        linha15 = Words.wordReplacer(" │       │ ");
                        linha12 = Words.wordReplacer("A LETRA DIGITADA NÃO EXISTE NA PALAVRA-CHAVE!");
                        
                    }
                    else if (lives == 2)
                    {
                        linha15 = Words.wordReplacer(" │      /│\\");
                        linha12 = Words.wordReplacer("A LETRA DIGITADA NÃO EXISTE NA PALAVRA-CHAVE!");

                    }
                    else if (lives == 1)
                    {
                        linha16 = Words.wordReplacer(" │      / \\");
                        linha12 = Words.wordReplacer("A LETRA DIGITADA NÃO EXISTE NA PALAVRA-CHAVE! ATENÇÃO, ÚLTIMA VIDA!");

                    }
                    else if (lives == 0)
                    {
                        // linha14 = Words.wordReplacer(" │      (😵)");//versao emoji
                        linha14 = Words.wordReplacer(" │      (O)");
                        linha17 = Words.wordReplacer("  │     ┌┐ ┌┐ ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        linha12 = Words.wordReplacer($"VOCÊ PERDEU! A PALAVRA ERA: {palavraEscondida}");
                        //linha19 = Words.wordReplacer("APERTE QUALQUER PARA SAIR"); - versão anterior
                        linha19 = Words.wordReplacer("APERTE [S] OU [Q] PARA SAIR");
                                                
                    }

                }                            
            }
        }       
    }

    class  Words //classe com o dicionario de palavras para o jogo. Pelo que entendi, métodos estáticos não precisam que se instancie um objeto para ter acesso em todas as demais classes
    {
        public static Dictionary<string, string> palavras = new Dictionary<string, string>(); // criando dict que armazenará pares de palavras e suas dicas
        public Words() // construtor para criar pelo menos 1 linha, não deixando o dict vazio
        {
            palavras.Add("FORCA", "JOGO"); // usando add para adicionar ao dicionario
        }
        public static void dictPalavras(string palavra, string dica) // metodo para adicionar usando palavra e dica como args
        {
            palavras.Add(palavra, dica); // passando os args para o metodo add, adicionando ao dicionario
        }
        // wordReplacer é uma versão alterada de CenterText acima, retornando o que deve ser escrito
        // forma encontrada para poder utilizar como argumento, dentro de CenterText, assim podendo imprimir texto dentro das margens, sem apagá-las
        public static string wordReplacer(string text = "", char starter = '║', char ends = '║', char sep = ' ', int width = 100) // cria um texto centralizado, aceitando como argumentos "end = primeiro e ultimo caractere da linha", "sep = caracter para usar como separador, que aparecerá antes e depois do texto até o tamanho da tela", "width = largura" todos os parâmetros são opcionais
        {
            int padWidth = (width - text.Length) / 2; // encontra a metada da largura, excluindo o tamanho do texto criado
            string palavra = text.PadLeft(text.Length + padWidth, sep).PadRight(width, sep); // PadLeft e PadRight criam caracteres de preenchimento "sep" em ambos os lados do texto, deixando centralizado na tela  
            string replacer = ("  " + starter + palavra + ends + "  "); // cria o texto centralizado na tela usando os "ends" como margem
            return replacer;

        }
        
        public static void AddWord(string palavra, string dica)
        {// metodo chamado para retornar tela de sucesso ao cadastrar, usa metodo dictPalavras para add ao dict. na classe, .Add gera uma ArgumentException caso chave já exista no dicionario
            dictPalavras(palavra, dica); 

            UserScreen telaAdd = new UserScreen();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear(); 
            telaAdd.CenterText("", starter: '╔', sep: '═', ends: '╗');
            telaAdd.CenterText(""); 
            telaAdd.CenterText("Palavra cadastrada com sucesso!");
            telaAdd.CenterText("");
            telaAdd.CenterText("");
            telaAdd.CenterText("Aperte qualquer tecla para continuar.");
            telaAdd.CenterText("");
            telaAdd.CenterText("");
            telaAdd.CenterText("");
            telaAdd.CenterText("");
            telaAdd.CenterText("");
            telaAdd.CenterText("");
            telaAdd.CenterText("");
            telaAdd.CenterText(" ┌───────┐ ");
            telaAdd.CenterText(" │       O ");
            telaAdd.CenterText(" │      /|\\ ");
            telaAdd.CenterText(" │      / \\ ");
            telaAdd.CenterText("  │     ┌───┐ ");
            telaAdd.CenterText(" _│_    │   │ ");
            telaAdd.CenterText("");
            telaAdd.CenterText("");
            telaAdd.CenterText("", starter: '╚', sep: '═', ends: '╝');
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(52, 18);
            Console.ReadKey(); // segura a tela ativa ate input do usuario

        }

        public static void AddWordAuto(string palavra, string dica) // usado para cadastrar palavras sem input
        {
            UserScreen telaAdd = new UserScreen(); //instancia o objeto para poder mostrar mensagens de erro abaixo

            try
            {
                dictPalavras(palavra, dica); // tenta adicionar palavras ao dicionario
            }
            catch (ArgumentException) // erro caso existam palavras repetidas no arquivo de base de dados ao carregar o programa
                                        // este erro nao deve acontecer, a nao ser que o csv seja alterado manualmente, entao corecao deve ser feita tambem manualmente
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Clear(); 
                telaAdd.CenterText("", starter: '╔', sep: '═', ends: '╗');
                telaAdd.CenterText(""); 
                telaAdd.CenterText("ATENÇÃO");
                telaAdd.CenterText($"PALAVRA REPETIDA: {palavra} ENCONTRADA NA BASE DE DADOS");
                telaAdd.CenterText("");
                telaAdd.CenterText("VERIFIQUE O ARQUIVO databasePalavras.CSV NA PASTA DO PROGRAMA");
                telaAdd.CenterText("E REMOVA ITENS DUPLICADOS");
                telaAdd.CenterText("");
                telaAdd.CenterText("");
                telaAdd.CenterText("");
                telaAdd.CenterText("");
                telaAdd.CenterText("Aperte qualquer tecla para continuar.");
                telaAdd.CenterText("");
                telaAdd.CenterText(" ┌───────┐ ");
                telaAdd.CenterText(" │      (O)");
                telaAdd.CenterText(" │      /|\\ ");
                telaAdd.CenterText(" │      / \\ ");
                telaAdd.CenterText("  │     ┌───┐ ");
                telaAdd.CenterText(" _│_    │   │ ");
                telaAdd.CenterText("");
                telaAdd.CenterText("");
                telaAdd.CenterText("", starter: '╚', sep: '═', ends: '╝');
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(52, 18);
                Console.ReadKey();
            }
        }

        public static List<string> GetWord() // metodo para gerar retorno aleatorio de palavras do dict
        {
            
            Random random = new Random(); // criando um objeto da classe Random
            int randomIndex = random.Next(0, palavras.Count); // Next pega o proximo objeto aleatorio gerado pelo objeto acima, dentro do range de 0 até o tamanho do dict(Count)
            KeyValuePair<string, string> randomPair = palavras.ElementAt(randomIndex); // .ElementAt é da Linq, extrai um par de valores do dicionario. randomIndex é usado como posição dentro do dict.

            // extraindo key e value do par acima
            string word = randomPair.Key;
            string tip = randomPair.Value;

            List<string> retorno = new List<string> { word, tip }; //retorna uma lista com uma palavra para o jogo, e a dica da palavra
            return retorno;
        }

    }

    class DictIO // classe para armazenar e ler o dicionario de palavras e dicas externamente (csv)

    {
        //public DictIO() // construtor, aparentemente desnecessario aqui
        //{
        //    ;
        //}
        public void DictIOWriter()
        {
            string path = DictPath(); // path está recebendo o caminho do csv do metodo DictPath
            using (var writer = new StreamWriter(path))  //StreamWriter escreve linha por linha no csv que está no argumento
            {
                foreach (var pair in Words.palavras) // para cada par de valores no dicionario
                {
                    writer.WriteLine("{0};{1};", pair.Key, pair.Value); // writer é o objeto criado acima, que aqui escreve a chave e o valor separados por ; no arquivo csv
                }
            }
        }

        public void DictIOReader() // le o arquivo csv
        {
            try // tenta encontrar o arquivo da base de dados na raiz do programa
            { 
            string path = DictPath(); // vide metodo acima
                using (StreamReader reader = new StreamReader(path))  //StreamReader le linhas do arquivo csv no argumento
                {
                    string line; // inicializa uma string para uso abaixo                   

                    while ((line = reader.ReadLine()) != null) // retorno do reader é passado para line, enquanto a linha não for vazia:
                    {
                        char delimiter = ';'; //delimitador para separar
                        string[] readWords = line.Split(delimiter); //split retorna uma array com os valores encontrados
                        Words.AddWordAuto(readWords[0], readWords[1]); // valores retornados da array, que devem ser respectivamente, palavra e dica
                    }
                }   
              
            }
            catch (FileNotFoundException) // caso o csv não exista ainda.. 
            {
                Words.AddWordAuto("BANANA", "FRUTA"); // .. adicionando algumas palavras caso o usuario queira jogar direto
                Words.AddWordAuto("MORANGO", "FRUTA");
                Words.AddWordAuto("JABUTICABA", "FRUTA");
                Words.AddWordAuto("CURITIBA", "CIDADE");
                Words.AddWordAuto("ANAPOLIS", "CIDADE");
                Words.AddWordAuto("CANOAS", "CIDADE");
            }
        }

        public string DictPath() // verifica o diretorio onde o programa esta instalado
        {
            // Busca o diretório de onde o programa está sendo executado. Codigo encontrado em 1 exemplo, ainda não compreendi 100%
            // como funciona, apenas que está retornando uma string com o diretorio raiz do programa
            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Combinando o diretorio retornado acima com o nome do arquivo csv
            string dictPath = Path.Combine(directory, "csvdatabasePalavras.csv");
            
            // retorno contendo o caminho + nome do arquivo
            return (dictPath);
            
        }
    }

    

}

//TODO: MÉTODO PARA REMOVER ENTRADAS INDESEJADAS DO DICIONARIO / VISUALIZAR PALAVRAS NO DICIONARIO

