using System;
using System.Collections.Generic;
 
namespace InterviewPractices
{
    class ObserverPattern
    {
        public interface IObserver
        {
            void Update(string video, string videoField);
        }
        public interface IObservable
        {
            void Add(IObserver o);
            void Remove(IObserver o);
            void Notify();
 
            void setNewVidoAndNotifyAll(string newVideo, string videoField);
           
 
        }
        public interface IDisplayEmlements
        {
            void Display();
        }
 
        public class TedTalk : IObservable
        {
            List<Object> Observers;
            string newVideo;
            string field;
 
            public TedTalk()
            {
                Observers = new List<object>();
            }
            public void Add(IObserver o)
            {
                Observers.Add(o);
              
            }
 
            public void Notify()
            {
                for(var i = 0; i< Observers.Count; i++)
                {
                   IObserver o = (IObserver)Observers[i];
                    o.Update(newVideo, field);
                }
            }
 
            public void Remove(IObserver o)
            {
                for(var i = 0; i < Observers.Count; i++)
                {
                    int index = Observers.IndexOf(o);
                   Observers.Remove(o);
                }
            }
 
            public void setNewVidoAndNotifyAll(string newVideo, string videoField)
            {
 
                this.newVideo = newVideo;
                this.field = videoField;
                Notify();
            }
        }
 
 
        public class Samanta : IObserver, IDisplayEmlements
        {
            TedTalk tedTalk;
            private string newVideo;
            private string videoField;
 
            public Samanta(TedTalk T)
            {
                this.tedTalk = T;
                this.tedTalk.Add(this);
            }
            public void Display()
            {
                Console.WriteLine("Samanta a new TedTalk added: " + this.newVideo + " . It's " + this.videoField);
            }
 
            public void Update(string video, string videoField)
            {
                this.newVideo = video;
                this.videoField = videoField;
                Display();
            }
 
        }
 
        public class John : IObserver, IDisplayEmlements
        {
            TedTalk tedTalk;
            private string newVideo;
            private string videoField;
 
            public John(TedTalk T)
            {
                this.tedTalk = T;
                this.tedTalk.Add(this);
            }
            public void Display()
            {
                Console.WriteLine("John a new TedTalk added: " + this.newVideo + " . It's " + this.videoField);
            }
 
            public void Update(string video, string videoField)
            {
                this.newVideo = video;
                this.videoField = videoField;
                Display();
            }
 
        }
 
        class subscribers
        {
            public static void Main(string[] args)
            {
                TedTalk tedtalk = new TedTalk();
 
                Samanta samanta = new Samanta(tedtalk);
                John john = new John(tedtalk);
 
                tedtalk.setNewVidoAndNotifyAll("Elon Musk new Interview 2018","Technology");
                tedtalk.setNewVidoAndNotifyAll("Albert Einstein ", "Documentry");
                tedtalk.setNewVidoAndNotifyAll("Evolution", "Biology");
                Console.ReadLine();
            }
        }
 
    }
 
   
}