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
- en récupérant l'instance créée pour la détuire au bout de 5 secondes : 
```csharp
GameObject clone = Instantiate(gameObject); 
Destroy(clone, 5f);
```
[voir usage dans CloneOnClick.cs](./Assets/Scripts/CloneOnClick.cs)

## Component (Accès à une instance, ajouter, détruire)

Pour récupérer un composant existant sur un gameObject, 
on utilise `GetComponent<MonComposant>()`, par exemple : 
```csharp
Rigidbody body = GetComponent<Rigidbody>();
```
Attention, le composant récupéré peut être nul (s'il n'existe pas)!
Voir usage dans [CubeController.cs](./Assets/Scripts/CubeController.cs).

Pour ajouter un composant sur un gameObject,
on utilise `gameObject.AddComponent<MonComposant>()`, par exemple : 
```csharp
gameObject.AddComponent<Rigidbody>();
```
Voir usage dans [Eye.cs](./Assets/Scripts/Eye.cs).

## Debug

Pour mettre en pause le moteur Unity :
```csharp
Debug.Break();
```
