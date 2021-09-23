# ensaama-start-2021

## Vie et Mort
Pour détruire un composant OU un gameObject :
```csharp
Destroy(gameObject);
// avec un délai de 3 secondes :
Destroy(gameObject, 3f);
```

Pour créer un gameObject à partir d'une source :
- existant dans la scène :
```csharp
Instantiate(gameObject);
```
