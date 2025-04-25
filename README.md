# 📐 Arquitetura em Camadas com DDD (Domain-Driven Design)

## A estrutura será baseada nos seguintes níveis principais:

* Apresentação (Frontend em Vue.js)
* Aplicação (C# – Camada de Serviços/Application Services)
* Domínio (C# – Entidades, Agregados, Regras de Negócio, Interfaces)
* Infraestrutura (C# – Acesso a dados via Entity Framework + MySQL)
  
# Atendimento aos Requisitos Funcionais (RF)
O DDD favorece o desenvolvimento guiado pelo domínio da aplicação, o que facilita a modelagem clara de processos como registro de entradas/saídas, controle de estoque, perfis de acesso e histórico de alterações (RF04, RF05, RF06, RF07, RF11).
A separação em camadas permite que funcionalidades como cadastro, edição, categorização e busca de itens (RF01, RF02, RF03, RF08, RF09, RF10) sejam desenvolvidas de forma coesa e escalável.
A camada de domínio garante que regras como ajuste automático de estoque ou controle de permissões por perfil sejam implementadas com clareza e sem acoplamento ao banco ou à interface.

# Atendimento aos Requisitos Não Funcionais (RNF)
RNF01 (Criptografia de dados sensíveis): tratada na camada de infraestrutura usando bibliotecas de segurança da plataforma .NET.
RNF02 a RNF06 (Interface, desempenho e compatibilidade): o uso do Vue.js permite uma interface responsiva, intuitiva e compatível com navegadores modernos e dispositivos móveis.
RNF07 (Adaptação sem reestruturação): DDD facilita a evolução do sistema sem impactar diretamente outras camadas — ideal para novos tipos de materiais ou regras de negócio.
RNF08 (LGPD): dados sensíveis podem ser isolados e protegidos com políticas claras de acesso e anonimização, centralizadas na camada de domínio e infraestrutura.

## Outros Benefícios da Arquitetura Escolhida

**Alta coesão e baixo acoplamento entre as camadas.**

**Facilidade de testes unitários e integração, especialmente nas camadas de domínio e aplicação.**

**Escalabilidade, tanto horizontal (mais usuários) quanto funcional (novas regras e recursos).**

**Manutenção facilitada, pois cada camada tem uma responsabilidade bem definida.**
