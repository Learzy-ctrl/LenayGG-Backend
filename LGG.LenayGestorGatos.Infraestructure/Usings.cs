﻿global using LGG.LenayGestorGatos.Aplication.Interfaces.Persistance;
global using LGG.LenayGestorGatos.Domain.ValueObjects;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using LGG.LenayGestorGatos.Aplication.Commons;
global using LGG.LenayGestorGatos.Infraestructure.DataContexts;
global using Microsoft.Extensions.DependencyInjection;
global using LGG.LenayGestorGatos.Domain.Interfaces.Infraestructure;
global using LGG.LenayGestorGatos.Infraestructure.Repositories;
global using LGG.LenayGestorGatos.Domain.DTOs.Persona;
global using System.Data;
global using LGG.LenayGestorGatos.Domain.Aggregates.Persona;
global using LGG.LenayGestorGatos.Domain.DTOs;
global using LGG.LenayGestorGatos.Domain.DTOs.Usuario;
global using System.Data.SqlClient;
global using LGG.LenayGestorGatos.Domain.Aggregates.Usuario;
global using FirebaseAdmin;
global using Google.Apis.Auth.OAuth2;
global using Dapper;
global using MySqlConnector;
global using FirebaseAdmin.Auth;
global using Firebase.Auth;