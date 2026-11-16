Console.WriteLine("==========================");
Console.WriteLine("---------VidaPet----------");
Console.WriteLine("==========================");

int opcao = 0;
List<string> codAnimais = new List<string>();
List<string> dadosTutorAnimal = new List<string>();
List<string> consultas = new List<string>();
List<string> consultasCanceladas = new List<string>();
int sequnciaConsultas = 0;
string codGerente = "123cba";


do
{
    Console.WriteLine("1 - Cadastrar animal");
    Console.WriteLine("2 - Nova consulta");
    Console.WriteLine("3 - Verificar consulta");
    Console.WriteLine("4 - Cancelar consulta");
    Console.WriteLine("0 - Sair");

    if(!int.TryParse(Console.ReadLine(), out opcao))
    {
        opcao = -1;
    }

    switch (opcao)
    {
        case 1:
            Console.WriteLine("Digite o nome do animal: ");
            string nomePet = Console.ReadLine().Trim().ToLower();
            if (string.IsNullOrWhiteSpace(nomePet)) {
                Console.WriteLine("Valor inválido");
                break;
            }
            Console.WriteLine("Digite o nome do tutor: ");
            string nomeTutor = Console.ReadLine().Trim().ToLower();
            if (string.IsNullOrWhiteSpace(nomeTutor))
            {
                Console.WriteLine("Valor inválido");
                break;
            }

            Console.WriteLine("Digite o telefone do tutor: ");
            string telTutor = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(telTutor))
            {
                Console.WriteLine("Valor inválido");
                break;
            }


            Console.WriteLine("Digite a especie: ");
            string especiePet = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(especiePet))
            {
                Console.WriteLine("Valor inválido");
                break;
            }

            Console.WriteLine("Digite a idade do animal: ");
            string idadePet = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(idadePet))
            {
                Console.WriteLine("Valor inválido");
                break;
            }



            string codPet = nomePet[..2] + nomeTutor[..2] + telTutor[^4..];
            dadosTutorAnimal.Add($"{nomePet};{nomeTutor};{telTutor};{especiePet};{idadePet};{codPet}");

            if(!codAnimais.Contains (codPet)) {
                codAnimais.Add(codPet);
                Console.WriteLine($"{nomePet} foi salvo(a) com o código {codPet} com sucesso!");
            } else   
            {
                Console.WriteLine("Animal já cadastrado em nossa base");
            }
            break;

        case 2:
            Console.WriteLine("Digite o código do animal, exemplo (abCD1234): ");
            codPet = Console.ReadLine().ToLower();

            int indicePet = codAnimais.IndexOf(codPet);

            if (indicePet == -1)
            {
                Console.WriteLine("Animal não encontrado, necessário realizar o cadastro do animal");
                break;
            } 

            string dados = dadosTutorAnimal[indicePet];
            string nomeAnimal = dados.Split(";")[0];

            Console.WriteLine($"Deseja realizar uma consulta para o(a) {nomeAnimal}? (sim ou nao)");
            string realizarConsulta = Console.ReadLine().Trim().ToLower();
            if (realizarConsulta == "nao" || realizarConsulta == "não")
            {
                Console.WriteLine("Agendamento cancelado");
                break;
            } else if (realizarConsulta != "sim")
            {
                Console.WriteLine("Opção inválida, somente sim ou nao");
                break;
            }

            sequnciaConsultas++;
            string codConsulta = sequnciaConsultas.ToString() + "-" + codPet;
            if (!consultas.Contains(codConsulta)) {
                consultas.Add(codConsulta);
                Console.WriteLine($"Consulta para {nomeAnimal} de código {codPet} foi agendada: ({codConsulta})");
            } 
            break;

        case 3:
            Console.WriteLine("Digite a consulta, exemplo (0-abCD1234): ");
            codConsulta = Console.ReadLine();
            if (consultas.Contains(codConsulta))
            {
                Console.WriteLine($"Consulta {codConsulta} está agendada");
            } else if (consultasCanceladas.Contains(codConsulta)) {
                Console.WriteLine($"Consulta {codConsulta} está cancelada");
            } else
            {
                Console.WriteLine($"Consulta inexistente");
            }
            break;

        case 4:
            Console.WriteLine("Digite seu código de gerente? (123cba)");
            string codLogin = Console.ReadLine();

            if (!codLogin.Equals(codGerente))
            {
                Console.WriteLine("Você não tem acesso");
                break;
            }

            Console.WriteLine("Qual consulta deseja cancelar?");
            codConsulta =  Console.ReadLine();

            if (consultas.Contains(codConsulta))
            {
                consultas.Remove(codConsulta);
                consultasCanceladas.Add(codConsulta);
                Console.WriteLine($"Consulta {codConsulta} está cancelada");
            } else
            {
                Console.WriteLine("Consulta inexistente");
            }

            break;

        case 0:
            Console.WriteLine("Programa encerrado");
            break;

        default:
            Console.WriteLine("Valor inválido");
            break;
    }

} while (opcao != 0);



