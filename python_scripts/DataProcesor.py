import polars as pl
import subprocess
import requests
import os

excel_path = "../assets/wood_sales.xlsx"
csv_path = "temporal.csv"
subprocess.run(["xlsx2csv", excel_path, csv_path])

df = pl.read_csv(csv_path, try_parse_dates=True)

df = df.with_columns([
    pl.col("Fecha").str.strptime(pl.Date, fmt="%Y-%m-%d", strict=False),
    pl.col("Fecha").dt.year().alias("Año"),
    pl.col("Fecha").dt.month().alias("Mes")
])

grouped = df.groupby(["Tipo de Madera", "Año", "Mes"]).agg([
    pl.col("Cantidad de ventas (unidades)").mean().alias("promedio_ventas"),
    pl.col("cantidad de stock").mean().alias("promedio_stock")
])


json_data = grouped.to_dicts()

url = "http://localhost:5177/api/resumen-maderas"
response = requests.post(url, json=json_data)

print(f"Status: {response.status_code}")
print(response.json())

os.remove(csv_path)
