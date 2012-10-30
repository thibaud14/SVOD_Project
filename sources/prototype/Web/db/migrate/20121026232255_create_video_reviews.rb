class CreateVideoReviews < ActiveRecord::Migration
  def change
    create_table :video_reviews do |t|
      t.string :message

      t.timestamps
    end
  end
end
