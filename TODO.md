
## Modulo 2
### 💡 Esercizio 4: Estensioni personalizzate
Crea una **classe statica di estensioni** che aggiunge funzionalità alle collezioni:
- Metodo `ToPrettyString()` che formatta gli oggetti in tabella.
- Metodo `Median()` per calcolare la mediana di una lista di numeri.
- Metodo `Chunk(int size)` per dividere una lista in sotto-liste di lunghezza fissa.

**🎯 Bonus:** usa `yield return` per rendere `Chunk()` lazily evaluated.

---

## ⚡ Modulo 3 – Async / Await

### 🌐 Esercizio 5: Download parallelo di dati
Simula il download di file da URL:
- Usa `HttpClient` con `async/await`.
- Mostra l’avanzamento dei download.
- Limita il numero di download concorrenti (usa `SemaphoreSlim`).

**🎯 Bonus:** implementa un “retry” automatico se un download fallisce.

---

## 🧠 Modulo 4 – Generics e Delegati

### 🧰 Esercizio 6: Repository generico
Crea una classe generica `Repository<T>` con operazioni CRUD:
- `Add(T item)`, `Remove(Predicate<T>)`, `Find(Func<T,bool>)`, `GetAll()`.
- Limita `T` a tipi che implementano un’interfaccia `IEntity` con `Id`.

**🎯 Bonus:** rendi il repository persistente tramite serializzazione JSON o XML.

---

### 🧰 Esercizio 7: Eventi e delegati
Simula un **sistema di sensori**:
- Classe `Sensore` con evento `OnMisuraRicevuta`.
- Classe `Monitor` che si iscrive e reagisce alle misure.
- Usa `EventHandler<T>` e `Action<T>` per gestire notifiche.

**🎯 Bonus:** implementa una pipeline di trasformazioni con **delegati compositi**.

---

## 🧩 Modulo 5 – Design Pattern

### 🏗️ Esercizio 8: Factory + Singleton
Implementa una **factory di notifiche**:
- Tipi di notifiche: `Email`, `SMS`, `Push`.
- `NotificationFactory` restituisce il tipo corretto in base a una stringa.
- Aggiungi un `Logger` come Singleton per tracciare ogni notifica inviata.

---

### 🏗️ Esercizio 9: Observer Pattern
Realizza un mini sistema di borsa:
- `Stock` notifica i suoi osservatori (`Investor`) quando il prezzo cambia.
- Ogni investor decide se “comprare” o “vendere”.
- Usa `IObservable<T>` e `IObserver<T>` oppure un’implementazione custom.

---

### 🏗️ Esercizio 10: Command Pattern
Crea un sistema di **undo/redo** per un editor di testo semplice:
- Comandi: `AddText`, `RemoveText`, `ReplaceText`.
- Ogni comando deve sapere come **eseguire** e **annullare** l’azione.
- Gestisci una stack per undo e redo.

---