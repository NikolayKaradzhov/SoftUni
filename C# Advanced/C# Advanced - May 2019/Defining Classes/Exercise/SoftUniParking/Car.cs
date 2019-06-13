﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registrationNumber;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            string result =
            $"Make: {Make}" + Environment.NewLine +
            $"Model: {Model}" + Environment.NewLine +
            $"HorsePower: {HorsePower}" + Environment.NewLine +
            $"RegistrationNumber: {RegistrationNumber}";

            return result;
        }
    }
}