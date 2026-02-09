# Jogo Gourmet

## Descrição

O **Jogo Gourmet** é uma aplicação desktop desenvolvida em WPF (Windows Presentation Foundation) usando C# e .NET 8.0. O jogo é uma versão do clássico "jogo das 20 perguntas" focado em pratos culinários. O computador tenta adivinhar o prato em que o jogador está pensando fazendo perguntas de sim/não, e aprende novos pratos à medida que joga.

O projeto foi criado como um exercício de programação e demonstra conceitos de interfaces gráficas, gerenciamento de estado e lógica de árvore de decisão.

## Funcionalidades Atuais

### Jogo Principal
- **Perguntas Iniciais**: Começa com perguntas pré-definidas sobre características dos pratos (ex.: "O prato que pensou é massa?").
- **Aprendizado**: Quando o computador não consegue adivinhar, ele aprende um novo prato perguntando qual era e uma característica distintiva.
- **Interface Simples**: Janelas intuitivas para interação com o usuário.

### Componentes do Projeto

#### Arquivos Principais
- **MainWindow.xaml/.cs**: Janela inicial que inicia o jogo.
- **Confirm.xaml/.cs**: Janela de confirmação onde as perguntas são feitas e respostas coletadas.
- **CriaPrato.xaml/.cs**: Janela para o usuário inserir um novo prato quando o computador erra.
- **ComparaPrato.xaml/.cs**: Janela para comparar o novo prato com um existente e criar uma nova pergunta.
- **Acerto.xaml/.cs**: Janela de vitória quando o computador acerta o prato.

#### Gerenciamento de Dados
- **PratoManager.cs**: Classe responsável por gerenciar as perguntas e pratos associados. Usa um `OrderedDictionary` para manter a ordem das perguntas.

#### Recursos
- Imagens: `interrogacao.jpg` (ponto de interrogação) e `exclamacao.png` (ponto de exclamação) para enriquecer a interface.

### Como Executar

1. **Pré-requisitos**:
   - Windows 10 ou superior
   - .NET 8.0 SDK instalado
   - Visual Studio 2022 ou similar com suporte a WPF

2. **Clonagem e Build**:
   ```bash
   git clone <url-do-repositorio>
   cd JogoGourmet
   dotnet build
   ```

3. **Execução**:
   ```bash
   dotnet run
   ```
   Ou abra o projeto no Visual Studio e execute em modo Debug/Release.

### Estrutura do Projeto
```
JogoGourmet/
├── MainWindow.xaml/.cs       # Janela principal
├── Confirm.xaml/.cs          # Janela de perguntas
├── CriaPrato.xaml/.cs        # Criação de novo prato
├── ComparaPrato.xaml/.cs     # Comparação de pratos
├── Acerto.xaml/.cs           # Tela de acerto
├── Manager/
│   └── PratoManager.cs       # Gerenciamento de pratos e perguntas
├── App.xaml/.cs              # Aplicação WPF
├── JogoGourmet.csproj        # Arquivo de projeto .NET
└── README.md                 # Este arquivo
```

## Tecnologias Utilizadas
- **Linguagem**: C#
- **Framework**: .NET 8.0
- **UI Framework**: WPF (Windows Presentation Foundation)
- **Estruturas de Dados**: OrderedDictionary para perguntas ordenadas

## Melhorias Futuras

O projeto tem potencial para expansões significativas. Aqui estão algumas ideias para desenvolvimento futuro:

### Funcionalidades Básicas
- **Persistência de Dados**: Salvar e carregar o estado do jogo (perguntas e pratos) em arquivo JSON ou banco de dados SQLite.
- **Mais Pratos Iniciais**: Expandir a base de conhecimento com mais pratos e perguntas pré-definidas.
- **Validação de Entrada**: Melhorar a validação dos nomes de pratos inseridos pelo usuário.

### Interface e UX
- **Design Moderno**: Atualizar a interface com Material Design ou Fluent Design para uma aparência mais atrativa.
- **Suporte a Temas**: Permitir alternância entre temas claro/escuro.
- **Animações**: Adicionar transições suaves entre janelas.
- **Ícones e Imagens**: Expandir o uso de recursos visuais para tornar o jogo mais envolvente.

### Funcionalidades Avançadas
- **Modo Multiplayer**: Permitir que dois jogadores humanos joguem um contra o outro.
- **Modo Online**: Conectar jogadores online para compartilhar conhecimentos de pratos.
- **Inteligência Artificial**: Implementar algoritmos de aprendizado de máquina para melhorar as perguntas.
- **Estatísticas**: Rastrear acertos, erros e pratos mais difíceis.
- **Modo Desafio**: Níveis de dificuldade com limite de perguntas.

### Internacionalização
- **Suporte a Múltiplos Idiomas**: Adicionar localização para português, inglês, espanhol, etc.
- **Pratos Regionais**: Permitir categorias de pratos por região ou cultura.

### Extensões Técnicas
- **Testes Unitários**: Adicionar testes para a lógica do PratoManager e outras classes.
- **Logging**: Implementar sistema de logs para depuração e análise.
- **Configuração**: Arquivo de configuração para personalizar o jogo.
- **API REST**: Expor uma API para integração com outros sistemas.
- **Versão Web**: Portar para Blazor ou ASP.NET Core para versão web.

### Outras Ideias
- **Áudio**: Adicionar efeitos sonoros e narração das perguntas.
- **Modo Tutorial**: Guiar novos jogadores através do jogo.
- **Compartilhamento**: Permitir exportar/importar bases de conhecimento.
- **Integração com APIs**: Conectar com APIs de receitas para enriquecer o jogo.

## Contribuição

Contribuições são bem-vindas! Para contribuir:

1. Fork o projeto
2. Crie uma branch para sua feature (`git checkout -b feature/nova-funcionalidade`)
3. Commit suas mudanças (`git commit -am 'Adiciona nova funcionalidade'`)
4. Push para a branch (`git push origin feature/nova-funcionalidade`)
5. Abra um Pull Request

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE.txt).

## Autor

Nicolas Sanchez Soares

---

Divirta-se jogando e aprendendo sobre pratos deliciosos!