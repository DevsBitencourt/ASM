# ASM

Arquitetura de Software e Solução

[![Build Status](https://img.shields.io/badge/build-passing-brightgreen)](https://github.com/DevsBitencourt/ASM/actions)
[![License](https://img.shields.io/github/license/DevsBitencourt/ASM)](LICENSE)

## 📋 Sumário

- [Descrição](#descrição)
- [Estrutura](#estrutura-do-projeto)
- [Pré-requisitos](#pré-requisitos)
- [Instalação](#instalação)
- [Scripts SQL](#scripts-sql)
- [Contato](#contato)

---

## Descrição

Este projeto traz como foco o desafio final da Pós Gradução em Arquitetura de Software e Soluções.

---

## Estrutura do Projeto

- /Business.Contract       - Contratos de negócio
- /Business.Models         - Modelos de dados do domínio
- /Business.Shared         - Componentes compartilhados
- /Business                - Lógica de negócio principal
- /Repository.Contract     - Contratos de persistência
- /Repository.Models       - Modelos de dados para persistência
- /Repository              - Implementações de acesso a dados
- /XPedidos                - Módulo XPedidos
- /XPedidos.Infrastructure - Infraestrutura e integrações externas
- /Docs                    - Documentação (ex: scripts SQL)


---

## Pré-requisitos

- [.NET 8.0+](https://dotnet.microsoft.com/download)
- SQL Server 2008+ (consulte a documentação dos scripts SQL)
- Visual Studio 2022 ou superior

> **Atenção**: Compilação do release gerado como auto suficiente.
---

## Scripts SQL

Os scripts para criação e manutenção do banco estão na pasta `/Docs/Scripts.sql`.

Caso prefira na pasta `Docs/ASM1.bak` há um backup com alguns registros em tabela.

> **Atenção**: Use SQL Server 2008 ou superior para garantir compatibilidade.

---

## Instalação

- [Download do programa](https://github.com/DevsBitencourt/ASM/releases/download/1.0.2/ASM.zip)
- Descompactar o programa
- No arquivo `appsettings.json` alterar a connectionString para que a mesma acesse o banco de dados.
- Executar o programa `XPedidos.exe` como administrador
- A aplicação está configurada para subir na porta 7074, mas poderá ser alterada por meio do `appsettings.json`
- Após finalizar o passo a passo a cima, por meio da rota que a aplicação gerou chamar o endpoint '/api-docs'.

---

## Contato

- [LinkedIn Bitencourt](https://www.linkedin.com/in/vitor-bitencourt-dev/)
- Email: vitor.bitencourt.vmb@gmail.com
