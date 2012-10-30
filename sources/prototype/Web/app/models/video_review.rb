class VideoReview < ActiveRecord::Base
  attr_accessible :message

  belongs_to :ref_star_ratings
  belongs_to :user
  belongs_to :video

end
