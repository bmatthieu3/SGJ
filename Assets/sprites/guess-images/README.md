# Ajouter une nouvelle image

Pour ajouter une nouvelle image, il suffit de l'ajouter dans le dossier courant (`Assets/sprites/guess-images`), avec un nom de fichier unique.

Il faut ensuite modifier le fichier `Assets/sprites/images.json` pour ajouter une entrée pour cette image dans le jeu. Il suffit de copier coller ce bout de code, et de le modifier pour correspondre à l'image ajoutée:

```json
,
        {
            "id": 7,
            "name": "bretzel",
            "path": "sprites/guess-images/bretzel.jpg",
            "source": "https://commons.wikimedia.org/wiki/File:Pretzel_01-14.jpg",
            "license": "CC BY-SA 3.0",
            "solution": ["bretzel", "pretzel", "bretz", "pretz", "bretzels", "pretzels", "bretzle", "pretzle", "bretzles", "pretzles", "bretzels pretzels", "pretzels bretzels"]
        }
```

**Notes :**
* Il faut bien penser à mettre une virgule `,` après le crocher fermant `}` de l'entrée correspondant à l'image précédente, et après le crochet fermant `}` de la fin de l'entrée, il ne faut pas en mettre (sauf si on ajoute une autre image derrière).
* L'attribut `id` doit être unique, et doit être incrémenté de 1 par rapport à l'entrée précédente. En vrai il n'est pas utilisés, peut être que ça pourrait servir plus tard...
* L'attribut `name` est le nom de l'image, ça pareil ce n'est pas utilisé dans le code pour l'instant.
* `path` est le chemin vers le nom de l'image que l'on vient d'ajouter. Il faut bien penser à mettre le bon chemin, en fonction de l'endroit où on se trouve dans le projet.
* `source` est le lien vers l'image qui a été récupérée sur internet
* `license` est la licence de l'image - c'est précisé sur Wikipedia par exemple, ça sert peut être à rien de la noter, mais bon ça coûte rien !
* `solutions` est la liste des solutions possibles pour cette image
* Il faut que ce bout de code soit insérer dans le fichier *avant* le crochet fermant `]` de la liste des images.
* Il faut aussi que l'image soit en format paysage, pour éviter que celle-ci ne soit trop déformée quand elle sera affichée