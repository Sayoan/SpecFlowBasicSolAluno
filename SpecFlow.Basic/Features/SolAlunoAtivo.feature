﻿Feature: Login - Sol Aluno
	Como um aluno do Sol Aluno
	Eu quero realizar login
	Para acessar minhas informações acadêmicas

@Test1
Scenario Outline: Aluno Ativo acessa Sol Aluno
	Given Acesso a pagina de login do Sol Aluno
	When Entro com as credenciais <username> e <password>
	And Clico no botao Login
	Then Deve entrar na pagina inicial do Sol Aluno 
Examples:
| username   | password |
|  114111564 | 123 |
| 114110112 | 123 |

@Test2
Scenario Outline: Aluno erra senha no acesso Sol Aluno
	Given Acesso a pagina de login do Sol Aluno
	When Aluno entra <username> e <password>
	And Clico no botao Login
	Then Deve aparecer uma mensagem de alerta 'Login ou senha inválido'
Examples:
| username   | password |
|  114111564 | 1234 |
| testuser_2 | Test@153 |


