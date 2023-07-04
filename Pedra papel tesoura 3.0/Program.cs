using System;

class Program
{

    static int rodadas;

    public static void Main(string[] args)
    {
        Start();
    }

    public static void Start()
    {
        DesenhaCabecalho(3);
        Console.WriteLine("  Digite \"start\" para iniciar");

        string iniciar;

        iniciar = Console.ReadLine();

        while (iniciar != "start")
        {
            DesenhaCabecalho(3);
            Console.WriteLine("Você não digitou \"start\", Digite \"start\" para iniciar ");

            iniciar = Console.ReadLine();
        }
        DefineRodadas();
    }

    public static void DesenhaCabecalho(int linhasExtras)
    {
        Console.Clear();
        Console.WriteLine(" ______________________________");
        Console.WriteLine("|   Pedra, Papel ou Tesoura    |");
        Console.WriteLine("|______________________________|");

        for (int i = 0; i < linhasExtras; i++)
        {
            Console.WriteLine("\n");
        }
    }
    public static void DefineRodadas()
    {
        DesenhaCabecalho(1);
        Console.WriteLine("Quantas rodadas você quer jogar ?");
        rodadas = Int32.Parse(Console.ReadLine());

        while (rodadas != 1 && rodadas != 3 && rodadas != 5 && rodadas != 7)
        {
            DesenhaCabecalho(1);
            Console.WriteLine("Você digitou um valor invalido de rodadas(escolha entre 1, 3, 5 e 7): ");
            rodadas = Int32.Parse(Console.ReadLine());
        }
        ControlaRodadas();
    }
    public static void ControlaRodadas()
    {
        int RodadaAtual = 1;
        int SeusPontos = 0;
        int PontosBot = 0;
        bool FimJogo = false;

        while (FimJogo != true)
        {
            DesenhaCabecalho(1);
            Console.WriteLine("          Rodada " + RodadaAtual.ToString() + "/" + rodadas + "         ");
            Console.WriteLine();
            Console.WriteLine("User: " + SeusPontos + " pontos  |  CPU: " + PontosBot + " pontos");

            switch (ExibeRodada())
            {
                case 0:
                    break;
                case 1:
                    SeusPontos++;
                    RodadaAtual++;
                    if (SeusPontos > rodadas / 2)
                    {
                        Console.WriteLine("Você VENCEU o JOGO !");
                        FimJogo = true;
                    }
                    break;
                case 2:
                    PontosBot++;
                    RodadaAtual++;
                    if (PontosBot > rodadas / 2)
                    {
                        Console.WriteLine("Você PERDEU o JOGO :(");
                        Console.WriteLine();
                        FimJogo = true;
                    }
                    break;
            }
            if (FimJogo == true)
            {
                Console.WriteLine("O jogo terminou ! Precione tecla \"o\" para reiniar o jogo");
                if (Console.ReadLine().ToUpper() == "O")
                {
                    Start();
                }
            }
            else
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("Precione tecla \"x\" para continuar, ou \"o\" para voltar");
                if (Console.ReadLine().ToUpper() == "O")
                {
                    Start();
                }
            }
        }
    }
    public static int ExibeRodada()
    {

        string[] PePaTe = new string[3]{
      "PEDRA",
      "PAPEL",
      "TESOURA"
  };

        Random rand = new Random();
        int Sorteio = rand.Next(PePaTe.Length);
        string EscolhaDaMaquina = PePaTe[Sorteio].ToUpper();

        string Escolha;


        Console.WriteLine("Escolhar entre pedra, papel e tesoura: ");
        Escolha = Console.ReadLine().ToUpper();
        Console.WriteLine();
        while (Escolha != "PEDRA" && Escolha != "PAPEL" && Escolha != "TESOURA")
        {
            Console.WriteLine("Sua esolha é invalida, escolhar entre pedra, papel e tesoura:");
            Escolha = Console.ReadLine().ToUpper();
        }

        Console.Write("A maquina escolheu: ");
        Console.WriteLine(EscolhaDaMaquina);
        Console.WriteLine("Sua escolha é: " + Escolha);
        Console.WriteLine();

        if (Escolha == EscolhaDaMaquina)
        {
            Console.WriteLine("A rodada EMPATOU");
            Console.WriteLine();
            return 0;
        }
        else if (Escolha == "PEDRA" && EscolhaDaMaquina == "TESOURA")
        {
            Console.WriteLine("Você GANHOU a rodada");
            Console.WriteLine();
            return 1;
        }
        else if (Escolha == "PAPEL" && EscolhaDaMaquina == "PEDRA")
        {
            Console.WriteLine("Você GANHOU a rodada");
            Console.WriteLine();
            return 1;
        }
        else if (Escolha == "TESOURA" && EscolhaDaMaquina == "PAPEL")
        {
            Console.WriteLine("Você GANHOU a rodada");
            Console.WriteLine();
            return 1;
        }
        else
        {
            Console.WriteLine("Você PERDEU a rodada");
            Console.WriteLine();
            return 2;
        }
    }
}