class RefVideoGenres < ActiveRecord::Base
  attr_accessible :name

  has_many :video_genres
  has_many :video, :through => :video_genres

end
