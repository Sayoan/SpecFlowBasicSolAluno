# SpecFlowBasicSolAluno
Passagem de parâmetros durante a execução sem utilizar instância objetos. Todas as classes [BINDING] terão acesso.

**int Type**
```sh
ScenarioContext.Current[“key“] = value;
var value = (int)ScenarioContext.Current[“key“]
```
 
**string Type**
```sh
ScenarioContext.Current[“key“] = value;
var value = (string)ScenarioContext.Current[“key“]
```
 

**Class object Type**
```sh
ScenarioContext.Current[“key“] = object;
var value = (objectType)ScenarioContext.Current[“objectName“]
```
**Demais contextos**

**Set a value**
```sh
ScenarioContext.Current.Add(string key, object value);
```

**Get a value**
```sh
var value = ScenarioContext.Current.Get<Type>(string Key);
  ```
  
  **IMPORTANTE**
  Note: This is not so difficult, but keep in mind, that the Context will be emptied for the next Scenario. You can pass data just between steps in the same Scenario.

