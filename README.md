# CalculadoraFinanceira
Aplicação desenvolvida durante as aulas de Projeto de Interface Web do curso técnico em Informática para Internet do [SENAI-MG](https://www.fiemg.com.br/senai/) com o objetivo de praticar a gestão de repositórios no GitHub.

## O que foi utilizado
- Biblioteca `Newtonsoft.Json` para serialização e deserialização de dados em JSON.
- Estruturas de dados `List<T>` para armazenar receitas e despesas.
- Laços de repetição e controle de fluxo para gerenciar a interação do usuário.

## Etapas implementadas
1. **Definição de classes**
    - [x] `Receita`: Representa uma receita com valor e descrição.
    - [x] `Despesa`: Representa uma despesa com valor e descrição.
    - [x] `Financas`: Agrupa listas de receitas e despesas.

2. **Funcionalidades**:
    - [x] **Adicionar Receita**: O usuário pode inserir uma nova receita, informando a descrição e o valor.
    - [x] **Adicionar Despesa**: O usuário pode inserir uma nova despesa, informando a descrição e o valor.
    - [x] **Calcular Saldo**: O programa calcula e exibe o saldo total, mostrando se está positivo, negativo ou zerado.
    - [x] **Gerar Relatório**: O usuário pode visualizar todas as receitas e despesas registradas, incluindo totais e saldo final.

3. **Persistência de dados**
    - [x] Os dados são salvos em um arquivo `financas.json`, permitindo que as informações sejam mantidas entre execuções do programa.
    - [x] Os dados são carregados automaticamente na inicialização do programa.

## Backlog
- [ ] Implementar opção para remover receitas e despesas previamente adicionadas.
- [ ] Permitir que o usuário visualize relatórios de receitas e despesas separados por mês.

## Conclusão
Esta aplicação foi desenvolvida com o objetivo de oferecer uma maneira simples de gerenciar receitas e despesas, permitindo ao usuário calcular seu saldo de forma rápida e prática. A implementação de novas funcionalidades e melhorias pode tornar a ferramenta ainda mais robusta e útil.