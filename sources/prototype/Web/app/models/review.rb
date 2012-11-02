class Review < ActiveRecord::Base
  attr_accessible :message, :star_rating
  belongs_to :video
  belongs_to :user

end
