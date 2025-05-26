✅ Resumo do Projeto
Tecnologias:

C#

MAUI (para app mobile)

SQLite (persistência local)

Funcionalidades obrigatórias:

1. Cadastro e Edição
Veículos

Tipos de combustíveis

Abastecimentos

2. Regras de exclusão
Ao excluir veículo → excluir seus abastecimentos

Combustível em uso não pode ser excluído

3. Navegação
App com NavigationPage e uma tela inicial com 3 botões:

Veículos

Combustíveis

Abastecimentos

Cada botão leva a uma lista com:

Botão "Adicionar" (abre tela de cadastro)

Clique no item → leva à tela de edição

4. Relatórios
Quantidade total por tipo de combustível

Percentual de uso por tipo de combustível

Média de consumo do carro (independente do tipo de combustível)

'''bash

/Model
  - Veiculo.cs
  - Combustivel.cs
  - Abastecimento.cs

/View
  - Paginas para lista/cadastro/edição

/ViewModel
  - Lógica e ligação com a UI (caso use MVVM)

'''
