# FaceDetection-SecurityAttendance
Detección de rostros aplicada en un mini sistema de seguridad con notificación vía SMS a través de un GSM Modem, y aplicada a la toma automática de lista de asistentes.
Hecho en C# en Visual Studio 2015
Para la parte de las notificaciones en el sistema de seguridad, necesita un Modem 3g de esos que dan las operadores con internet movil, ya que mediante comandos AT nos hacemos del control del modem para enviar SMS.

Los SMS se envian cada 5 minutos si detecta algun rostro.
