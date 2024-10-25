# Contacts 
## Progetto svolto da @AndreaGros (4^B inf)
Il progetto è una semplice rubrica interattiva dove si possono svolgere diverse azioni tramite la classe Contatto qui di seguito:

```
public string Nominativo;
public string Telefono;

public Contatto(string nominativo, string telefono)
{
    Nominativo = nominativo;
    Telefono = telefono;
}

public override string ToString()
{
    return $"{Nominativo} - {Telefono}";
}
```