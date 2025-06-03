# Gestor de Frotas

Aplicativo móvel desenvolvido com .NET MAUI para gerenciamento de frotas de veículos, permitindo o controle de veículos, combustíveis e abastecimentos. Feito como trabalho de conclusão de semestre na faculdade 

# 🚀 Funcionalidades
Cadastro e Edição de Veículos: Adicione, edite e exclua veículos da frota.
Gerenciamento de Combustíveis: Mantenha um registro dos tipos de combustíveis utilizados.

Registro de Abastecimentos: Registre abastecimentos associando veículos e combustíveis, incluindo informações como litros abastecidos, preço por litro, quilometragem e data.

Relatórios:

Quantidade total abastecida por tipo de combustível.

Percentual de uso por tipo de combustível.

Média de consumo por veículo (km/l).

Regras de Exclusão:

Ao excluir um veículo, todos os seus abastecimentos são excluídos.

Não é possível excluir um combustível que esteja em uso por algum abastecimento.

# 🛠️ Tecnologias Utilizadas
Linguagem: C#

Framework: .NET MAUI

Banco de Dados: SQLite (persistência local)

# 📱 Estrutura do Projeto
Models/: Contém as classes de modelo, como Veiculo, Combustivel e Abastecimento.

Services/: Inclui o SQLiteHelper.cs, responsável pelas operações de banco de dados.

Views/: Contém as páginas da interface do usuário, como cadastro e listagem de veículos, combustíveis e abastecimentos.

Resources/: Arquivos de recursos, como imagens e estilos.

App.xaml e AppShell.xaml: Configurações e estruturação da aplicação.
pt.wikipedia.org
github.com
+2
github.com
+2
uece.br
+2
