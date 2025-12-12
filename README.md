# Proyecto Final - Programación Paralela

## 📋 Descripción

Este proyecto es el trabajo final de la asignatura de Programación Paralela, desarrollado en C# utilizando Visual Studio.  El proyecto demuestra la implementación de conceptos de programación paralela y concurrente para mejorar el rendimiento de aplicaciones.

## 🚀 Características

- Implementación de programación paralela en C#
- Uso de técnicas de concurrencia
- Optimización de rendimiento mediante procesamiento paralelo
- Solución Visual Studio completa (. sln)

## 🛠️ Tecnologías Utilizadas

- **Lenguaje**: C#
- **IDE**: Visual Studio
- **Framework**: .NET

## 📁 Estructura del Proyecto

```
ProyectoFinal_ProgramacionParalela/
├── ProyectoFinal_ProgramacionParalela.sln    # Solución de Visual Studio
├── ProyectoFinal_ProgramacionParalela/        # Proyecto principal
├── . gitignore                                 # Archivos ignorados por Git
└── . gitattributes                             # Atributos de Git
```

## 💻 Requisitos Previos

- Visual Studio 2019 o superior
- .NET Framework o .NET Core (según la versión del proyecto)
- Sistema operativo:  Windows, macOS o Linux

## 🔧 Instalación

1. Clona el repositorio:
```bash
git clone https://github.com/eudyyuniorramires/ProyectoFinal_ProgramacionParalela. git
```

2. Navega al directorio del proyecto: 
```bash
cd ProyectoFinal_ProgramacionParalela
```

3. Abre el archivo de solución: 
```bash
ProyectoFinal_ProgramacionParalela.sln
```

4. Restaura los paquetes NuGet (si es necesario):
   - En Visual Studio: `Tools` > `NuGet Package Manager` > `Restore NuGet Packages`

## ▶️ Ejecución

1. Abre la solución en Visual Studio
2. Configura el proyecto de inicio (si hay múltiples proyectos)
3. Presiona `F5` o haz clic en el botón "Start" para ejecutar el proyecto
4. O desde la línea de comandos: 
```bash
dotnet run
```

## 📚 Conceptos de Programación Paralela Implementados

### Posibles implementaciones: 
- **Task Parallel Library (TPL)**: Uso de `Task` y `Task<T>` para operaciones asíncronas
- **Parallel Class**:  Métodos como `Parallel.For`, `Parallel.ForEach`
- **PLINQ**: Consultas LINQ paralelas
- **Async/Await**: Programación asíncrona
- **Thread Pool**: Gestión eficiente de hilos
- **Concurrent Collections**: Colecciones thread-safe

## 🧪 Pruebas

Para ejecutar las pruebas del proyecto:

```bash
dotnet test
```

## 📊 Rendimiento

El proyecto demuestra mejoras de rendimiento mediante:
- Distribución de carga en múltiples núcleos
- Reducción de tiempos de ejecución
- Uso eficiente de recursos del sistema

## 🤝 Contribuciones

Las contribuciones son bienvenidas. Por favor: 

1. Haz un Fork del proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 👨‍💻 Autor

**Eudy Yunior Ramires**
- GitHub: [@eudyyuniorramires](https://github.com/eudyyuniorramires)

## 📝 Licencia

Este proyecto es un trabajo académico para la asignatura de Programación Paralela. 

## 📞 Contacto

Si tienes preguntas o sugerencias sobre el proyecto, no dudes en abrir un issue en el repositorio. 

---

⭐ Si este proyecto te fue útil, considera darle una estrella en GitHub! 
