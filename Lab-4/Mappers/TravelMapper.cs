using Laboratorium_nr3.Models;
public class TravelMapper
    {
        public static Travel FromEntity(TravelEntity entity)
        {
            return new Travel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Start_Date = entity.Start_Date,
                End_Date = entity.End_Date,
                Start_Place = entity.Start_Place,
                End_Place = entity.End_Place,
                Participants = entity.Participants,
                Guide = entity.Guide,
            };
        }

        public static TravelEntity ToEntity(Travel model)
        {
            return new TravelEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Start_Date = model.Start_Date,
                End_Date = model.End_Date,
                Start_Place = model.Start_Place,
                End_Place = model.End_Place,
                Participants = model.Participants,
                Guide = model.Guide,
            };
        }
    }

