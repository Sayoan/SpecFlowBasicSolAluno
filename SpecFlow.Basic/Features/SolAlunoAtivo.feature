Feature: Acesso Sol Aluno
	Acesso ao sistema SOL Aluno

@Test1
Scenario Outline: Aluno Ativo acessa Sol Aluno
	Given Aluno acessa Sol Aluno
	When Aluno entra <username> e <password>
	And Clica no botao Login
	Then Aluno acessa com sucesso
Examples:
| username   | password |
|  114111564 | 123 |
| 114110112 | 123 |

@Test2
Scenario Outline: Aluno erra senha no acesso Sol Aluno
	Given Aluno acessa Sol Aluno
	When Aluno entra <username> e <password>
	And Clica no botao Login
	Then Aluno nao faz login
Examples:
| username   | password |
|  114111564 | 1234 |
| testuser_2 | Test@153 |


