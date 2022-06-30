using System;
using AppSoftware.LicenceEngine.Common;
using AppSoftware.LicenceEngine.KeyGenerator;

namespace TestLicenseKey
{
    public class License
    {
        public static void Generate()
        {
            while (true)
            {
                // Here in SampleKeyGenerator is the full set of KeyByteSet used to generate the licence key.
                // You should change these values in your solution.

                var keyByteSets = new[]
                {
                    new KeyByteSet(keyByteNumber: 1, keyByteA: 67, keyByteB: 4, keyByteC: 65),
                    new KeyByteSet(keyByteNumber: 2, keyByteA: 43, keyByteB: 255, keyByteC: 12),
                    new KeyByteSet(keyByteNumber: 3, keyByteA: 21, keyByteB: 132, keyByteC: 32),
                    new KeyByteSet(keyByteNumber: 4, keyByteA: 5, keyByteB: 43, keyByteC: 44),
                    new KeyByteSet(keyByteNumber: 5, keyByteA: 78, keyByteB: 9, keyByteC: 32),
                    new KeyByteSet(keyByteNumber: 6, keyByteA: 133, keyByteB: 21, keyByteC: 54),
                    new KeyByteSet(keyByteNumber: 7, keyByteA: 29, keyByteB: 34, keyByteC: 178),
                    new KeyByteSet(keyByteNumber: 8, keyByteA: 1, keyByteB: 98, keyByteC: 88)
                };

                // A unique key will be created for the seed value. This value could be a user ID or something
                // else depending on your application logic.

                int seed = new Random().Next(0, int.MaxValue);

                Console.WriteLine("Seed (for example user ID) is:");
                Console.WriteLine(seed);

                // Generate the key ... 

                var pkvKeyGenerator = new PkvKeyGenerator();

                string licenceKey = pkvKeyGenerator.MakeKey(seed, keyByteSets);

                Console.WriteLine("Generated licence key is:");
                Console.WriteLine(licenceKey);

                // The values output can now be copied into the SampleKeyVerification console app to demonstrate
                // verification.

                Console.WriteLine("\nCopy these values to a running instance of SampleKeyVerification to test key verification.");

                Console.WriteLine("\nPress any key to generate another licence key.");

                Console.ReadKey();
            }
        }
    }
}
