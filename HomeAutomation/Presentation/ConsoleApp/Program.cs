using System;
using HomeAutomation.Application.Services;
using HomeAutomation.Application.Commands;
using HomeAutomation.Core.Entities;
using HomeAutomation.Core.Interfaces;
using PaymentHandlers;


class Program
{
    static void Main()
    {
        // Create receivers
        Light livingRoomLight = new Light();
        Thermostat thermostat = new Thermostat();

        // Create commands
        ICommand turnOnLight = new TurnOnLightCommand(livingRoomLight);
        ICommand turnOffLight = new TurnOffLightCommand(livingRoomLight);
        ICommand adjustThermostat22 = new AdjustThermostatCommand(thermostat, 22);
        ICommand adjustThermostat25 = new AdjustThermostatCommand(thermostat, 25);

        // Create invoker
        RemoteControlService remoteControl = new RemoteControlService();

        // Execute and undo commands
        Console.WriteLine("Executing Turn On:");
        remoteControl.SetCommand(turnOnLight);
        remoteControl.PressButton();
        remoteControl.PressUndoButton();

        Console.WriteLine("Executing Turn Off:");
        remoteControl.SetCommand(turnOffLight);
        remoteControl.PressButton();
        remoteControl.PressUndoButton();

        Console.WriteLine("Executing Adjust Thermostat:");
        remoteControl.SetCommand(adjustThermostat22);
        remoteControl.PressButton();

        remoteControl.SetCommand(adjustThermostat25);
        remoteControl.PressButton();
        
        Console.WriteLine("Undoing Adjust Thermostat:");
        remoteControl.PressUndoButton();
        remoteControl.PressUndoButton();

        // Payment handling
        decimal cardBalance = 50m;
        decimal cashOnHand = 30m;
        decimal amountToPay = 40m;

        var cashHandler = new CashPaymentHandler(cashOnHand);
        var cardHandler = new CardPaymentHandler(cardBalance);
        cardHandler.SetSuccessor(cashHandler);

        Console.WriteLine("Processing payment:");
        cardHandler.HandlePayment(amountToPay);
    }
}
