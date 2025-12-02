# Título do projeto: Inventário Dinamico.

# Alunos: Bruno Luis Pereira, Guilherme Theis, Luis Quintino, Paulo Henrique S., Ramires Silva Paes e Rafael dos Santos Pereira.

**Professores orientadores:** Claudinei Dias e Luiz Carlos Camargo.

**Justificativa:** O principal objetivo do software é fornecer às instituições públicas uma ferramenta prática 
e eficiente para o gerenciamento de estoque. Ao promover um controle mais organizado e 
transparente dos materiais, busca-se otimizar a previsão de demandas e agilizar o processo 
de reposição de itens, contribuindo diretamente para a redução de custos e o aumento da 
eficiência operacional no qual o principal beneficiado foi a **Escola municipal anaburgo**.

**Descrição do APP:** Pretende-se desenvolver um sistema de gestão de estoque capaz de atender às necessidades 
específicas das instituições públicas, garantindo o acompanhamento em tempo real dos 
recursos (materiais de escritório, produtos de higiene, produtos alimentícios etc.). Dessa 
forma, espera-se impulsionar a transparência na utilização dos recursos, promover uma 
melhor organização dos processos e assegurar um uso responsável dos insumos, refletindo 
em melhorias nos serviços oferecidos à comunidade. 


## A estrutura será baseada nos seguintes níveis principais:

* Apresentação (Frontend em Vue.js)
* Aplicação (C# – Camada de Serviços/Application Services)
* Domínio (C# – Entidades, Agregados, Regras de Negócio, Interfaces)
* Infraestrutura (C# – Acesso a dados via Entity Framework + MySQL)
  
# Atendimento aos Requisitos Funcionais (RF)
O DDD favorece o desenvolvimento guiado pelo domínio da aplicação, o que facilita a modelagem clara de processos como registro de entradas/saídas, controle de estoque, perfis de acesso e histórico de alterações (RF04, RF05, RF06, RF07, RF11).
A separação em camadas permite que funcionalidades como cadastro, edição, categorização e busca de itens (RF01, RF02, RF03, RF08, RF09, RF10) sejam desenvolvidas de forma coesa e escalável.
A camada de domínio garante que regras como ajuste automático de estoque ou controle de permissões por perfil sejam implementadas com clareza e sem acoplamento ao banco ou à interface.
Esses são os requisitos funcionais da nossa aplicação:

•	RF01: Permitir o cadastro de itens (nome, categoria, quantidade, data de validade, etc.).
•	RF02: Categorizar materiais (ex: material de escritório, higiene, alimentos).
•	RF03: Atualizar informações de itens existentes (quantidade, status).
•	RF04: Registrar entradas (compras, doações) com data, responsável e motivo.
•	RF05: Registrar saídas (distribuição, uso) com justificativa, setor beneficiado e responsável.
•	RF06: Ajustar automaticamente o saldo do estoque após cada operação.
•	RF07: Definir perfis de acesso (ex: administrador, operador, consultor) com permissões específicas.
•	RF08: Cadastrar e gerenciar usuários (nome, cargo, setor, contato).
•	RF09: Buscar itens por nome, categoria ou código.
•	RF10: Filtrar registros por data, setor ou responsável.
•	RF11: Manter histórico completo de alterações (quem fez, quando e o que mudou).


# Atendimento aos Requisitos Não Funcionais (RNF)
RNF01 (Criptografia de dados sensíveis): tratada na camada de infraestrutura usando bibliotecas de segurança da plataforma .NET.
RNF02 a RNF06 (Interface, desempenho e compatibilidade): o uso do Vue.js permite uma interface responsiva, intuitiva e compatível com navegadores modernos e dispositivos móveis.
RNF07 (Adaptação sem reestruturação): DDD facilita a evolução do sistema sem impactar diretamente outras camadas — ideal para novos tipos de materiais ou regras de negócio.
RNF08 (LGPD): dados sensíveis podem ser isolados e protegidos com políticas claras de acesso e anonimização, centralizadas na camada de domínio e infraestrutura.

Esses são os requisitos não funcionais da nossa aplicação:

•	RNF01: Criptografar dados sensíveis (ex: senhas).
•	RNF02: Interface intuitiva, com menus claros em português.
•	RNF03: Tempo de aprendizado não superior a 2 horas para usuários básicos.
•	RNF04: Tempo de resposta inferior a 2 segundos para operações críticas.
•	RNF05: Funcionar em navegadores modernos (Chrome, Firefox, Edge) e dispositivos móveis.
•	RNF06: Compatibilidade com sistemas operacionais Windows, Linux e Android.
•	RNF07: Adaptar-se a novas categorias de materiais sem necessidade de reestruturação do código.
•	RNF08: Cumprir a Lei Geral de Proteção de Dados (LGPD) no tratamento de informações.

## Prints da telas com resumo.
<img width="751" height="802" alt="image" src="https://github.com/user-attachments/assets/bfda4c1f-e26b-42e6-932b-9694c2448436" />


**1. Tela de Login**

A tela de login é a primeira interface apresentada ao usuário ao acessar o sistema. Sua função é garantir a segurança e o controle de acesso ao sistema.

**Elementos da Tela:**

Título: Sistema de Gestão de Estoque Público

Campo “Nome de usuário”: utilizado para identificação do usuário.

Campo “Senha”: utilizado para autenticação segura.

Botão “Entrar”: realiza o acesso ao sistema após validação dos dados.

Link “Esqueceu sua senha?”: permite a recuperação da senha.

**Menu Lateral de Navegação**

Localizado à esquerda da tela, permite acesso rápido às funcionalidades principais do sistema:

Estoque Geral – Visualização completa de todos os itens.

Cadastro de Itens – Inserção de novos materiais no estoque.

Registrar Entrada/Saída – Controle de movimentação dos itens.

Usuários – Gerenciamento de usuários do sistema.

Relatórios – Emissão de relatórios de controle do estoque.


<img width="601" height="602" alt="image" src="https://github.com/user-attachments/assets/324c526d-e7dd-4b3a-950f-2caad8e55d34" />

**A Tela de Registro de Movimentação** é utilizada para controlar as entradas e saídas de itens do estoque. 
Nela, o usuário informa o tipo de movimentação, a data, o item (busca por nome ou código), a quantidade, o setor beneficiado e a justificativa. Ao final, é possível registrar, cancelar ou limpar os campos, garantindo um controle organizado, seguro e rastreável dos materiais da escola.


<img width="615" height="598" alt="image" src="https://github.com/user-attachments/assets/8cf1dfa2-bb7b-4874-81c5-8180775ee21a" />

**A Tela de Cadastro de Itens** é utilizada para inserir novos materiais no estoque da escola. 
Nela, o usuário informa o nome do item, a categoria, a quantidade, o setor beneficiado e a justificativa. Ao final, pode salvar, cancelar ou limpar os campos, garantindo um cadastro organizado e padronizado dos itens do inventário.


<img width="616" height="619" alt="image" src="https://github.com/user-attachments/assets/dfbdd472-37a5-42d2-9cac-af4e4144c212" />

**A Tela de Administração de Usuários** é responsável pelo gerenciamento dos usuários do sistema. 
ela é possível visualizar informações como nome, cargo, setor, contato e perfil de acesso. Também há a opção de adicionar novo usuário, permitindo controlar quem pode acessar e operar o sistema de inventário de forma segura e organizada.


<img width="608" height="600" alt="image" src="https://github.com/user-attachments/assets/10f83b90-8c1a-4cd6-82a8-e263b7a79166" />

**A Tela de Relatórios de Movimentação** permite gerar relatórios personalizados sobre as entradas e saídas de itens do estoque. O usuário pode filtrar por data inicial, categoria do item, tipo de movimentação e setor responsável.
Ao final, é possível exportar os dados em Excel ou PDF, facilitando o controle, a análise e a prestação de contas da escola.

<img width="595" height="508" alt="image" src="https://github.com/user-attachments/assets/c60158e2-236d-43f2-9311-9f747f974aad" />

**A Tela de Configurações permite** ajustar as principais preferências do sistema, como perfis de acesso dos usuários, segurança e criptografia de dados, adição ou modificação de categorias de materiais e a personalização da interface (idioma e tema). Essa tela garante maior controle, segurança e adaptação do sistema às necessidades da escola.

<img width="601" height="427" alt="image" src="https://github.com/user-attachments/assets/b5cad380-f2f7-42b5-9707-5c617ff61eea" />

**A Tela de Perfis de Acesso permite o gerenciamento** dos níveis de permissão dos usuários do sistema. Nela é possível visualizar os perfis de Administrador, Operador e Visualizador, com suas respectivas permissões. Também é possível editar perfis existentes, adicionar novos perfis e salvar as alterações, garantindo mais segurança e controle no acesso às funcionalidades do sistema.

<img width="605" height="431" alt="image" src="https://github.com/user-attachments/assets/e43d8666-e866-423d-878a-f65f8690a8c8" />

**A Tela de Gerenciamento de Categorias de Materiais** permite editar, excluir e adicionar novas categorias de itens do estoque, como materiais de escritório, higiene, alimentos e limpeza. Também é possível salvar as alterações, garantindo que o sistema permaneça organizado, atualizado e adaptado às necessidades da escola.



**Requisitos para preparar o ambiente de desenvolvimento**

**1. Requisitos de Hardware**
Computador com: Processador dual-core ou superior

Mínimo 8 GB de RAM (ideal 16 GB)

Pelo menos 20 GB livres em disco

Acesso à internet para instalação de dependências e uso de GitHub.

**2. Sistema Operacional**

Windows 10/11, Linux (Ubuntu, Mint, etc.) ou macOS

Permissão de instalação de softwares (Node, banco de dados, etc.).

**3. Ferramentas de Desenvolvimento**
Editor / IDE
Visual Studio Code (recomendado)

Extensões úteis:

ESLint / Prettier

Suporte a Vue/React (caso use)

GitLens

**3.1. Controle de Versão**

Git instalado

Conta no GitHub/GitLab/Bitbucket para hospedar o código.

**4. Backend (API)**

Node.js LTS instalado

npm ou yarn para gerenciamento de pacotes

Framework backend (por exemplo):

Express.js (rotas, middlewares)

Dependências típicas:

dotenv (variáveis de ambiente)

cors

jsonwebtoken (se tiver autenticação)

bcrypt (hash de senha)

ORM (por ex. Sequelize, Prisma ou similar)

**5. Banco de Dados**

Um SGBD instalado localmente ou em servidor:

MySQL / MariaDB ou

PostgreSQL ou

SQL Server (se já estiver usando)

Ferramenta gráfica para gerenciar o BD (opcional, mas ajuda):

DBeaver / MySQL Workbench / SQL Server Management Studio etc.

Criar:

Banco de dados da aplicação

Usuário e senha específicos para o sistema

Script inicial de criação de tabelas (Itens, Movimentações, Usuários, Perfis etc.).

**6. Frontend (Interface Web)**

Framework SPA (ajuste para o que você estiver usando):

Vue.js, React ou Angular

Ferramentas:

npm create vite@latest (se usar Vite) ou CLI do framework

Bibliotecas úteis:

Biblioteca de componentes (ex.: Bootstrap, Tailwind, Vuetify, etc.)

Biblioteca de gráficos (ex.: Chart.js) para o painel

Biblioteca para chamadas HTTP (axios, fetch)

**7. Outras Configurações Importantes**

Arquivo .env com:

URL do banco de dados

Porta da API (ex.: PORT=3000)

Segredo JWT (se houver login)

Scripts no package.json:

"dev" para rodar o backend

"dev" para rodar o frontend

Definir padrão de branch e commits (Git flow básico).

Opcional: Docker para padronizar o ambiente (API + BD + frontend).





## Outros Benefícios da Arquitetura Escolhida

**Alta coesão e baixo acoplamento entre as camadas.**

**Facilidade de testes unitários e integração, especialmente nas camadas de domínio e aplicação.**

**Escalabilidade, tanto horizontal (mais usuários) quanto funcional (novas regras e recursos).**

**Manutenção facilitada, pois cada camada tem uma responsabilidade bem definida.**
