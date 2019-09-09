# CalculateInterestSolution

Aplicação desenvolida para prova de código na Softplan, que realiza o cálculo de juros compostos.

##  Técnicas e boas práticas aplicadas ao teste: 

* Containers.

* Healthchecks.

* Logs estuturados [Serilog](https://github.com/serilog/serilog).

* Variáveis de ambiente para configuração dinâmica dos containers.

* Testes unitários e de integração.

* Swagger.

* Resiliência a falhas (retry pattern) utilizando [Polly](https://github.com/App-vNext/Polly).

## Arquitetura

Foi aplicada uma versão simplificado e conceitual da arquitetura Hexagonal(ou Ports & Adapters) ao projeto, utilizando alguns conceitos de DDD como Aggregate Root (CompoundInterest.cs) e Value Objects (Amount.cs, Months.cs, InterestRate.cs).

![modelo](https://github.com/luisfernandomoraes/CalculateInterestSolution/blob/develop/docs/hex_arch_concept.png)
