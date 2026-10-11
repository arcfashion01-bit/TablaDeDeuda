using Spectre.Console;

decimal monto = AnsiConsole.Ask<decimal>("Ingrese el [green]monto del préstamo[/]:"); 
decimal tasaAnual = AnsiConsole.Ask<decimal>("Ingrese la [green]tasa de interés anual[/] (%):"); 
int meses = AnsiConsole.Ask<int>("Ingrese el [green]plazo del préstamo[/] (en meses):");

decimal i = tasaAnual / 12 / 100;

decimal cuota = monto * i * (decimal)Math.Pow((double)(1 + i), meses) / (decimal)(Math.Pow((double)(1 + i), meses) - 1); cuota = Math.Round(cuota, 2);

var tabla = new Table(); 

tabla.Border = TableBorder.Rounded; 
tabla.AddColumn("No. de cuota"); 
tabla.AddColumn("Pago de cuota"); 
tabla.AddColumn("Interés a pagar"); 
tabla.AddColumn("Abono a capital"); 
tabla.AddColumn("Saldo");

decimal saldo = monto;

for (int cuotaNum = 1; cuotaNum <= meses; cuotaNum++)
{    
decimal interes = Math.Round(saldo * i, 2);
decimal abono = Math.Round(cuota - interes, 2); 
{
 if (cuotaNum == meses)
 abono = saldo;
 cuota = interes + abono;
}
 saldo = Math.Round(saldo - abono, 2);

  tabla.AddRow(
cuotaNum.ToString(),
cuota.ToString("N2"),
interes.ToString("N2"),
abono.ToString("N2"),
saldo.ToString("N2")
  );
}

AnsiConsole.Write(tabla);
AnsiConsole.MarkupLine("\n[green]Tabla generada correctamente.[/]");