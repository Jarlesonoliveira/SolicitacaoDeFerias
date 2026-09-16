# Solicitação de Férias

Aplicação de console em C# para validar solicitações de férias.

## Regras

- A data final deve ser posterior à data inicial.
- O início deve ocorrer entre segunda e quarta-feira.
- O início não pode ser no dia anterior a um feriado.
- A solicitação deve ter pelo menos 40 dias de antecedência.
- O período deve ter no máximo 30 dias.
- O período deve ter no mínimo 10 dias.

## Arquitetura

- O modelo de domínio contém `SolicitacaoFerias` e `Feriado`.
- Cada regra implementa `IRegraDeFerias`, seguindo o padrão Strategy.
- `ValidacaoDeRegra` orquestra as estratégias e retorna um resultado, sem escrever no console.
- `IFeriadoRepository` e `IRelogio` são portas do domínio, permitindo testes determinísticos.
- `FeriadoCsvRepository` é um adaptador de infraestrutura.
- A injeção de dependência é configurada somente em `Program`.

## Tecnologias utilizadas

### Aplicação

- **C#** como linguagem de programação.
- **.NET 5.0** como target framework e runtime da aplicação.
- **Microsoft.NET.Sdk** para compilação dos projetos.
- **Aplicação de console** como interface de entrada e saída.
- **Microsoft.Extensions.DependencyInjection 7.0.0** para injeção de dependência.
- **CSV** como fonte dos feriados nacionais.
- **System.IO** para leitura do arquivo de feriados.
- **DateTime** para regras de datas, duração e antecedência.

### Testes e qualidade

- **xUnit 2.4.2** para testes unitários.
- **Microsoft.NET.Test.Sdk 17.3.2** para descoberta e execução dos testes.
- **xunit.runner.visualstudio 2.4.5** para integração dos testes com o Visual Studio e VS Code.
- **Coverlet Collector 3.1.2** para coleta de cobertura de código.
- **Moq 4.18.4**, **Moq.AutoMock 3.5.0**, **Moq.Analyzers 0.0.9**, **Moq.Dapper 1.0.6** e **NSubstitute 4.2.2** como bibliotecas auxiliares disponíveis nos projetos de teste.

### Solução e ferramentas

- **MSBuild e NuGet** para compilação e gerenciamento de pacotes.
- **Visual Studio Code** como editor.
- **C# Dev Kit** e extensão **C#** para suporte à linguagem, testes e depuração.
- Arquivo `.sln` para organizar a aplicação e os projetos de teste.

## Execução

É necessário ter o .NET SDK compatível com `net5.0` instalado.

```text
dotnet test SolicitacaoDeFerias.sln
dotnet run --project SolicitacaoDeFerias/SolicitacaoDeFerias.csproj
```

## Cobertura de testes

Cobertura medida no projeto `SolicitacaoDeFerias_Test`:

- Linhas: **33,08%** (44 de 133)
- Branches: **11,53%** (3 de 26)
- Testes executados: **1 aprovado**

Para gerar o relatório de cobertura novamente:

```text
dotnet test SolicitacaoDeFerias_Test/SolicitacaoDeFerias_Test.csproj --collect:"XPlat Code Coverage"
```

A cobertura atual é parcial. Os próximos testes devem exercitar principalmente os cenários inválidos das regras de negócio e os caminhos de erro.