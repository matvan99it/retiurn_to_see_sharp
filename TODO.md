# 🧠 ROADMAP – Ripasso C# Avanzato (Console App)
# Durata: 4 settimane | Impegno: 4–5 ore/giorno | 5 giorni/settimana

settimana_1:
  tema: "OOP avanzata e basi solide"
  obiettivo: "Riprendere la padronanza della programmazione a oggetti in C#, con ereditarietà, interfacce e polimorfismo."
  giorni:
    giorno_1:
      focus: "Ripasso base di sintassi, classi e oggetti"
      obiettivi:
        - Ripassare classi, costruttori, proprietà, metodi, override e ToString().
        - Creare una piccola gerarchia di classi con ereditarietà semplice.
      esercizi:
        - "Mini progetto: modellare una gerarchia di Animali con suoni diversi."
        - "Esercizio propedeutico per il sistema di noleggio veicoli."
    giorno_2:
      focus: "Esercizio 1 – Sistema di noleggio veicoli (Parte 1)"
      obiettivi:
        - Definire classi base e derivate (Veicolo, Auto, Moto, Furgone).
        - Implementare interfaccia INoleggiabile.
        - Usare polimorfismo per stampare informazioni.
    giorno_3:
      focus: "Esercizio 1 – Sistema di noleggio veicoli (Parte 2)"
      obiettivi:
        - Implementare GestoreNoleggi per gestire il flusso dei veicoli.
        - Gestire input da console e stampa di report.
        - Bonus: serializzazione JSON con System.Text.Json.
    giorno_4:
      focus: "Esercizio 2 – Gestione dipendenti con ereditarietà e interfacce"
      obiettivi:
        - Creare la classe astratta Dipendente e derivate.
        - Calcolare stipendi e premi.
        - Usare interfacce e metodi virtuali.
    giorno_5:
      focus: "Ripasso e mini test"
      obiettivi:
        - Rivedere il codice dei giorni precedenti.
        - Aggiungere test manuali e nuovi scenari.
        - Migliorare la formattazione e la struttura dei file.

settimana_2:
  tema: "LINQ, collezioni e metodi di estensione"
  obiettivo: "Allenarsi con le query LINQ e creare metodi di estensione personalizzati."
  giorni:
    giorno_6:
      focus: "Ripasso LINQ"
      obiettivi:
        - Rivedere IEnumerable, lambda, Select, Where, GroupBy, OrderBy.
        - Sperimentare query expressions vs fluent syntax.
    giorno_7:
      focus: "Esercizio 3 – Analisi di dati con LINQ"
      obiettivi:
        - Creare una lista di ordini e filtrare con LINQ.
        - Trovare i top 3 clienti e fare medie per categoria.
    giorno_8:
      focus: "Esercizio 4 – Estensioni personalizzate"
      obiettivi:
        - Creare metodi di estensione generici.
        - Implementare Median(), Chunk(), ToPrettyString().
        - Usare yield return per ottimizzare le prestazioni.
    giorno_9:
      focus: "Mini progetto di riepilogo LINQ"
      obiettivi:
        - Combinare LINQ e classi custom in un piccolo report interattivo.
    giorno_10:
      focus: "Revisione e debug"
      obiettivi:
        - Analizzare codice, prestazioni e leggibilità.
        - Introdurre test semplici con dati mock.

settimana_3:
  tema: "Async/Await, Generics e Delegati"
  obiettivo: "Gestire concorrenza, task asincroni e programmazione generica."
  giorni:
    giorno_11:
      focus: "Introduzione a async/await"
      obiettivi:
        - Ripassare Task, async/await e HttpClient.
        - Creare esempi semplici di operazioni parallele.
    giorno_12:
      focus: "Esercizio 5 – Download parallelo di dati"
      obiettivi:
        - Simulare download multipli.
        - Limitare la concorrenza con SemaphoreSlim.
        - Aggiungere un sistema di retry automatico.
    giorno_13:
      focus: "Esercizio 6 – Repository generico"
      obiettivi:
        - Creare una classe Repository<T> con metodi CRUD.
        - Usare constraints di tipo (where T : IEntity).
        - Bonus: serializzazione JSON/XML.
    giorno_14:
      focus: "Esercizio 7 – Eventi e delegati"
      obiettivi:
        - Simulare un sistema di sensori.
        - Usare EventHandler<T> e delegati anonimi.
        - Implementare catene di trasformazione.
    giorno_15:
      focus: "Ripasso e consolidamento"
      obiettivi:
        - Rivedere async, delegati e generics.
        - Creare un mini progetto combinato (Repository asincrono).

settimana_4:
  tema: "Design Pattern fondamentali"
  obiettivo: "Applicare i pattern principali per strutturare il codice in modo professionale."
  giorni:
    giorno_16:
      focus: "Introduzione ai Design Pattern"
      obiettivi:
        - Rivedere Singleton, Factory, Observer, Command.
        - Capire quando e perché usarli.
    giorno_17:
      focus: "Esercizio 8 – Factory + Singleton"
      obiettivi:
        - Implementare NotificationFactory.
        - Aggiungere Logger singleton.
        - Simulare l’invio di notifiche multiple.
    giorno_18:
      focus: "Esercizio 9 – Observer Pattern"
      obiettivi:
        - Creare un sistema di stock/observer.
        - Notificare investitori al cambio prezzo.
    giorno_19:
      focus: "Esercizio 10 – Command Pattern"
      obiettivi:
        - Implementare comandi undo/redo in un editor testuale.
        - Gestire stack di comandi e ripristino stato.
    giorno_20:
      focus: "Progetto finale di riepilogo"
      obiettivi:
        - Integrare 2–3 pattern in un unico mini progetto.
        - Documentare e commentare il codice.
        - Scrivere README finale e checklist di competenze.

obiettivi_finali:
  - Piena padronanza di OOP, LINQ e async/await.
  - Capacità di progettare codice modulare e scalabile.
  - Conoscenza pratica di almeno 4 design pattern fondamentali.
  - Abitudine alla scrittura pulita e commentata di codice C#.
