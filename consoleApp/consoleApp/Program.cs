using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace consoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(@"../../../");
            driver.Navigate().GoToUrl("https://eksisozluk.com/giris");
            Console.WriteLine("Giriş için 1 dakika bekleniyor...");
            // Waiting user to logging in.
            System.Threading.Thread.Sleep(60000);
            // Finds writer's own web page.

            IWebElement me = driver.FindElement(By.XPath("/html/body/header/div/nav[1]/ul/li[6]/a"));
            me.Click();
            Console.WriteLine("Anasayfanıza yönlendirildi.");
            System.Threading.Thread.Sleep(4000);

            // In Eksi Sozluk, the most entry owner writer has less than 60 thousand entries. 
            for (int j = 0; j < 50000; j++)
            {

                // Finds writer's own web page.
                //Please check xpaths before running this program! Eksisozluk may have changed.
                IWebElement me1 = driver.FindElement(By.XPath("//*[@class='not-mobile']/a"));
                me1.Click();

                System.Threading.Thread.Sleep(4000);

                for (int i = 1; i < 11; i++)
                {
                    string s = "" + i;

                    try
                    {
                        // Deleting command has 3 steps: Edit, Delete and Confirm Elements.
                        IWebElement edit = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/section/div[3]/div/div/div[" + s + "]/ul/li/footer/div[2]/div/a"));
                        edit.Click();                                   // /html/body/div[2]/div[2]/div[2]/section/div[3]/div/div/div[1]/ul/li/footer/div[2]/div/a
                        Console.WriteLine("Düzenle seçeneği");

                        System.Threading.Thread.Sleep(3000);

                        try
                        {
                            IWebElement delete = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/section/div[3]/div/div/div[" + s + "]/ul/li/footer/div[2]/div/ul/li[3]/a"));
                            delete.Click();                             //    /html/body/div[2]/div[2]/div[2]/section/div[3]/div/div/div[10          ]/ul/li/footer/div[2]/div/ul/li[3]/a
                        }
                        catch
                        {
                            //IWebElement delete = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/section/div[3]/div/div/div[" + s + "]/ul/li/footer/div[2]/div/ul/li[3]/a"));
                            //delete.Click();
                        }


                        Console.WriteLine("Sil seçeneği");
                        System.Threading.Thread.Sleep(3000);

                        IWebElement confirm = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/section/form[2]/fieldset/div[2]/button[1]"));
                        confirm.Click();                                    ///html/body/div[2]/div[2]/div[2]/section/form[1]/fieldset/div[2]/button[1]
                        Console.WriteLine("Silindi");                   // /html/body/div[2]/div[2]/div[2]/section/form[1]/fieldset/div[2]/button[1]
                    }

                    catch
                    {

                    }
                    // Eksi Sozluk prohibits deleting more than 2 entries in a minute. So, system will be wait.
                    System.Threading.Thread.Sleep(25000);

                }
            }
        }
    }
}
